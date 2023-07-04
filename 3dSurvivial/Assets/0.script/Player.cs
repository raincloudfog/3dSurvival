using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    Camera cam;

    Rigidbody rigid;
    
    CapsuleCollider capsuleCollider;

    Vector3 pos; // 플레이어 이동 할때 쓸 저장소
    Vector3 posX; // 플레이어 x값 저장소
    Vector3 posZ; // 플레이어 z값 저장소

    float x, z;
    [SerializeField]
    float Originspeed = 5;
    
    float speed; // 플레이어 이동 속도
    // 6월 26일 이동속도 확인 하는 코드
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
    float rotationSpeed = 5f; // 캐릭터 회전 속도
    float JumpPower = 5f;
    float camX, camY;
    float currentCameraRotationX;
    float raycastDistace = 2f;

    public bool isSit = false; // 기본 앉아있지 않으니 false;
    bool isGround = false;
    public bool ischeck = false;

    RaycastHit hit; // 오브젝트 확인 용 레이캐스트
    public GameObject Object; // 오브젝트 확인용



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
        Move();
        CameraMove();
        CameraMoveY();
        IsGround();
        CheckObject();
        CheckDesk();
    }


   
    /// <summary>
    /// 땅인지 확인하기 위한 함수
    /// </summary>
    void IsGround() 
    {
        if(Physics.Raycast(transform.position, Vector3.down, capsuleCollider.bounds.extents.y + 0.0001f,LayerMask.GetMask("Ground")))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }

    void Move() // 캐릭터 이동 
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        posX = transform.right * x;
        posZ = transform.forward * z;
        pos = posX + posZ;
        pos.Normalize(); 
        
        transform.Translate(pos * Time.deltaTime * speed, Space.World);

    }
    void CameraMove() // 캐릭터 마우스 방향으로 캐릭터 회전값 변경
    {
        if (ItemManager.Instance.inventoryActivated == false || GameManager.Instance.dontmovemouse == true)
            return;
        camX = Input.GetAxisRaw("Mouse X");                                
        transform.Rotate(Vector3.up,  camX * rotationSpeed, Space.World);
        cam.transform.Rotate(transform.right, camY, Space.World);
        
    }
    /// <summary>
    /// 카메라가 상하로 움직이는 함수
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

    void Sit() // 앉기 함수
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

    void RunOn() // 달리기온 
    {
        speed = Originspeed * 2;
        InputManager.Instance.AddFunction(KeyCode.LeftShift, RunOff);
    }
    void RunOff() // 달리기 오프
    {
        speed = Originspeed;
        InputManager.Instance.AddFunction(KeyCode.LeftShift, RunOn);
    }

    void Jump() // 점프 
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



    void CheckObject()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 15f)) // 박스로 바꿀 것
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
