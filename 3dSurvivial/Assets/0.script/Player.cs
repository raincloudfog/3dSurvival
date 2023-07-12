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

    public AudioSource audioSource; // �ȱ� �Ҹ�

    float speed; // �÷��̾� �̵� �ӵ�
    // 6�� 26�� �̵��ӵ� Ȯ�� �ϴ� �ڵ�
    public float OriGinSpeed
    {
        get
        {
            return Originspeed;
        }
    }
    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }
    //
    float rotationSpeed = 5f; // ĳ���� ȸ�� �ӵ�
    float JumpPower = 5f;
    float camX, camY;
    float currentCameraRotationX;
    float raycastDistace = 2f;

    public bool isSit = false; // �⺻ �ɾ����� ������ false;
    bool isGround = false;
    public bool ischeck = false;

    RaycastHit hit; // ������Ʈ Ȯ�� �� ����ĳ��Ʈ
    public GameObject Object; // ������Ʈ Ȯ�ο�
    


    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        rigid = GetComponent<Rigidbody>();
        cam = Camera.main;
        speed = Originspeed;
        //InputManager.Instance.AddFunction(KeyCode.X, Sit);
        InputManager.Instance.AddFunction(KeyCode.LeftShift, RunOn);
        InputManager.Instance.AddFunction(KeyCode.Space, Jump);
       
    }

    // Update is called once per frame
    void Update()
    {
        CheckObject();

        if (GameManager.Instance.isRunning == true)
            return;
        Move();
        CameraMove();
        CameraMoveY();
        IsGround();

    }


   
    /// <summary>
    /// ������ Ȯ���ϱ� ���� �Լ�
    /// </summary>
    void IsGround() 
    {
        if(Physics.Raycast(transform.position, Vector3.down, capsuleCollider.bounds.extents.y + 0.5f,LayerMask.GetMask("Ground")))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
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

        if ((x != 0 || z != 0) && audioSource.isPlaying == false && isGround == true)
        {            
            audioSource.Play();
        }
        

    }
    void CameraMove() // ĳ���� ���콺 �������� ĳ���� ȸ���� ����
    {
        if (ItemManager.Instance.inventoryActivated == false || GameManager.Instance.dontmovemouse == true)
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
        if (ItemManager.Instance.inventoryActivated == false || GameManager.Instance.dontmovemouse == true)
            return;

        camY = Input.GetAxisRaw("Mouse Y");
        float cameraY = -camY;
        currentCameraRotationX += cameraY;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -30, 30);

        cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0, 0);
    }


    void RunOn() // �޸���� 
    {
        speed = GameManager.Instance.tiredness ? Originspeed : Originspeed * 2;
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


    void CheckObject()
    {
       
        if (Physics.BoxCast(transform.position, transform.lossyScale * 0.5f,transform.forward,out hit,Quaternion.identity, 5f)) // �ڽ��� �ٲ� ��
        {
            Object = hit.collider.gameObject;
            ischeck = true;
        }
        else
        {
            Object = null;
            ischeck = false;
        }
    }

}
