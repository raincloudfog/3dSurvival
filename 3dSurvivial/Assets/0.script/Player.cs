using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    Camera cam;

    Rigidbody rigid;
    
    CapsuleCollider capsuleCollider;

    Vector3 pos; // �÷��̾� �̵� �Ҷ� �� �����
    Vector3 posX; // �÷��̾� x�� �����
    Vector3 posZ; // �÷��̾� z�� �����

    float x, z;
    [SerializeField]
    float Originspeed = 5;
    float speed; // �÷��̾� �̵� �ӵ�
    float rotationSpeed = 5f; // ĳ���� ȸ�� �ӵ�
    float JumpPower = 5f;
    float camX, camY;
    float currentCameraRotationX;
    float raycastDistace = 2f;

    public bool isSit = false; // �⺻ �ɾ����� ������ false;
    bool isGround = false;
    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        rigid = GetComponent<Rigidbody>();
        cam = Camera.main;
        speed = Originspeed;
        InputManager.Instance.AddFunction(KeyCode.X, Sit);
        InputManager.Instance.AddFunction(KeyCode.LeftShift, RunOn);
        InputManager.Instance.AddFunction(KeyCode.Space, Jump);        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CameraMove();
        CameraMoveY();
        IsGround();
        check();
        CheckDesk();
    }


    /// <summary>
    /// ������Ʈ�� Ȯ���ϱ����� �÷��̾��� �Լ�
    /// </summary>
    void check() 
    {
        Ray ray = new Ray();
        ray.origin = transform.position;
        ray.direction = transform.forward;
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistace))
        {
            if (hit.collider.GetComponent<ObjectClass>() == true)
            {

            }
                //hit.collider.GetComponent<ObjectClass>().PickUp();
        }
    }
    /// <summary>
    /// ������ Ȯ���ϱ� ���� �Լ�
    /// </summary>
    void IsGround() 
    {
        if(Physics.Raycast(transform.position, Vector3.down, capsuleCollider.bounds.extents.y + 0.0001f,LayerMask.GetMask("Ground")))
        {
            isGround = true;
        }
    }

    void Move() // ĳ���� �̵� 
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        posX = transform.right * x;
        posZ = transform.forward * z;
        pos = posX + posZ;
        pos.Normalize(); 
        
        transform.Translate(pos * Time.deltaTime * speed, Space.World);

    }
    void CameraMove() // ĳ���� ���콺 �������� ĳ���� ȸ���� ����
    {
        if (ItemManager.Instance.inventoryActivated == false)
            return;
        camX = Input.GetAxisRaw("Mouse X");                                
        transform.Rotate(Vector3.up,  camX * rotationSpeed, Space.World);
        cam.transform.Rotate(transform.right, camY, Space.World);
        
    }
    /// <summary>
    /// ī�޶� ���Ϸ� �����̴� �Լ�
    /// </summary>
    void CameraMoveY()
    {
        if (ItemManager.Instance.inventoryActivated == false)
            return;

        camY = Input.GetAxisRaw("Mouse Y");
        float cameraY = -camY;
        currentCameraRotationX += cameraY;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -30, 30);

        cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0, 0);
    }

    void Sit() // �ɱ� �Լ�
    {
        isSit = !isSit;
        if(isSit == true)
        {
            //cam.transform.position = new Vector3(0, -0.5f, 0);
            transform.localScale = new Vector3(1, 0.5f, 1);
            speed = Originspeed * 0.5f;            
        }
        else
        {
            //cam.transform.position = new Vector3(0, 1, 0);
            transform.localScale = new Vector3(1, 1, 1);
            speed = Originspeed;            
        }        
    }

    void RunOn() // �޸���� 
    {
        speed = Originspeed * 2;
        InputManager.Instance.AddFunction(KeyCode.LeftShift, RunOff);
    }
    void RunOff() // �޸��� ����
    {
        speed = Originspeed;
        InputManager.Instance.AddFunction(KeyCode.LeftShift, RunOn);
    }

    void Jump() // ���� 
    {
        if(isGround == false)
        {
            return;
        }
        rigid.velocity = Vector3.up * JumpPower;
        isGround = false;        
    }      
    void CheckDesk()
    {
        RaycastHit hit;
        if(Physics.BoxCast(transform.position, transform.lossyScale / 2, transform.forward, out hit,Quaternion.identity, 1f))
        {
            if(hit.collider.CompareTag("Desk") == true)
            {


                InputManager.Instance.AddFunction(KeyCode.E, UIManager.Instance.CreftBoxOn);

            }
            
        }
        if (hit.collider == null)
        {
            
            UIManager.Instance.CreftBoxOff();
        }
    }
}
