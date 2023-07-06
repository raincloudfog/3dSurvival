using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 이 코드는 뭐가 더 최적화에 좋은지 확인하는 과정에서 주석이 많습니다.
public class ObjectClass : MonoBehaviour
{

    public Item _item; // 기본 아이템 값;

    public Inventory inventory; // 인벤토리 연결된상태

    protected Player player;
    protected Hands hands;

    //아이템 타입 변수 선언

    protected int Hp = 5; // 나무, 금광 체력;

    public virtual void PickUp() // 아이템 획득 추상 함수
    {
    }
        
    protected void NoPickup() // 아이템이 없는걸로 바꿔준다.
    {
        // 아무것도 할 수 없게 하는 용도
    }

    private void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }
        if (hands == null)
        {
            hands = FindObjectOfType<Hands>();
        }
        if(inventory == null)
        {
            inventory = FindObjectOfType<Inventory>();
        }
        
    }    

    private void FixedUpdate()
    {
        Vector3 playerpos = player.transform.position;
        Vector3 pos = transform.position;

        float distance = (playerpos - pos).sqrMagnitude;
        if(distance <= 3)
        {
            if(GetComponent<Tree>() == false && GetComponent<OreRock>() == false)
                InputManager.Instance.AddFunction(KeyCode.E, PickUp); // 플레이어 감지하면 픽업 사용
        }
        else if(distance > 3) // 만약 근처에 플레이어가 없을 경우 아이템을 줍지 못한다.
        {
            if(InputManager.Instance.Keyactions.ContainsKey(KeyCode.E) == false)
                InputManager.Instance.AddFunction(KeyCode.E, NoPickup);
        }
    }
    protected virtual void Init()
    {

    }
}
