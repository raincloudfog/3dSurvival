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
    float rotationSpeed = 5f; // 캐릭터 회전 속도
    float JumpPower = 5f;
    float camX, camY;
    float currentCameraRotationX;

    public bool isSit = false; // 기본 앉아있지 않으니 false;
    bool isGround = true;
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
        
    }

    void IsGround()
    {
        if(Physics.Raycast(transform.position, Vector3.down, capsuleCollider.bounds.extents.y + 0.0001f,LayerMask.GetMask("Ground")))
        {
            isGround = true;
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
        
        camX = Input.GetAxisRaw("Mouse X");
        
        
                
        transform.Rotate(Vector3.up,  camX * rotationSpeed, Space.World);
        cam.transform.Rotate(transform.right, camY, Space.World);
        
    }
    void CameraMoveY()
    {
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
            cam.transform.position = new Vector3(0, -0.5f, 0);
            transform.localScale = new Vector3(1, 0.5f, 1);
            speed = Originspeed * 0.5f;
            
        }
        else
        {
            cam.transform.position = new Vector3(0, 1, 0);
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

   
}
