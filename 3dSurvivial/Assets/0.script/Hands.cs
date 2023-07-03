using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    Animator anim; // 애니메이션    
    [SerializeField] Player player;
    [SerializeField] ObjectClass ObjCComponent;
    [SerializeField] PigBT Pig;
    [SerializeField]public GameObject _object; // 플레이어한태 받은 오브젝트
    float timer = 0;
    private void Awake()
    {

    }
    private void Start()
    {
        anim = GetComponent<Animator>(); // 나중에 수정해서 인스펙터로 직접 넣을 것.
        
    }
    private void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            ActiveOn();
        }*/
        if(Input.GetMouseButton(0))
        {
            ActiveOn();
        }
        if(Input.GetMouseButtonUp(0))
        {
            ActiveOff();
        }
    }
    void ActiveOn()
    {             
        anim.SetBool("Active", true); // 움직이기 애니메이션        
        GameManager.Instance.isActive = true; // 상호작용중
        CheckObject();                                             
    }
    void ActiveOff()
    {
        anim.SetBool("Active", false); // 움직이는 애니메이션 끝
        GameManager.Instance.isActive = false; // 상호작용 끝
        CheckOut();
    }
    /// <summary>
    /// 오브젝트들 확인하는 코드
    /// </summary>
    void CheckObject()
    {
        timer += Time.deltaTime;
        if(player.Object == null)
        {
            //Debug.Log("플레이어의 오브젝트가 비어있습니다.");
            return;
        }
        _object = player.Object;

        if (_object.GetComponent<ObjectClass>() != null)
        {
            ObjCComponent = _object.GetComponent<ObjectClass>();
            ObjCComponent.PickUp();
            //Debug.Log(ObjCComponent.name);
        }
        else if(_object.GetComponent<PigBT>() == true)
        {
            Pig = _object.GetComponent<PigBT>();
            if(timer > 2)
            {
                timer = 0;
                Pig.pig.Hp -= 1;
            }
            
            //Debug.Log(Pig.pig.Hp);
        }
       


        if (ObjCComponent == null)
        {
            ObjCComponent = null;
        }
        
    }
    void CheckOut()
    {
        ObjCComponent = null;                
    }
   
}
