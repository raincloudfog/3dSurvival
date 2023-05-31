using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 이 코드는 뭐가 더 최적화에 좋은지 확인하는 과정에서 주석이 많습니다.
public abstract class ObjectClass : MonoBehaviour
{

    protected Player player;
    protected Hands hands;

    protected int Hp = 5; // 나무, 금광 체력;

    public abstract void PickUp(); // 아이템 획득 추상 함수
    protected void NoPickup() // 아이템이 없는걸로 바꿔준다.
    {
        // 아무것도 할 수 없게 하는 용도
    }

    private void Start()
    {
        if(player ==null)
        {
            player = FindObjectOfType<Player>();
        }        
        if(hands == null)
        {
            hands = FindObjectOfType<Hands>();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + Vector3.up, transform.lossyScale * 1.5f);
    }

    private void FixedUpdate()
    {
        Vector3 playerpos = player.transform.position;
        Vector3 pos = transform.position;

        float distance = (playerpos - pos).sqrMagnitude;
        if(distance <= 2)
        {
            InputManager.Instance.AddFunction(KeyCode.E, PickUp); // 플레이어 감지하면 픽업 사용
        }
        else if(distance > 2) // 만약 근처에 플레이어가 없을 경우 아이템을 줍지 못한다.
        {
            if(InputManager.Instance.Keyactions.ContainsKey(KeyCode.E) == false)
                InputManager.Instance.AddFunction(KeyCode.E, NoPickup);
        }
    }

    /*private void FixedUpdate() 
    {
        // 대각선 방향 배열
        Vector3[] directions = {
            Vector3.left,Vector3.right,Vector3.forward,Vector3.back,
        Vector3.left + Vector3.forward, // 좌상
        Vector3.left + Vector3.back,    // 좌하
        Vector3.right + Vector3.forward, // 우상
        Vector3.right + Vector3.back     // 우하
        ,Vector3.zero
        }; // 더좋은 방법이 있을거 같음. 찾으면 그때 바꾸는 걸로

        foreach (Vector3 direction in directions)
        {
            RaycastHit hit; // 플레이어 감지용

            if (Physics.BoxCast(transform.position, transform.localScale * 0.1f, direction.normalized * 0.1f, out hit, Quaternion.identity, 0.5f)) // 
            {                
                if (hit.collider.CompareTag("Player"))
                {
                    InputManager.Instance.AddFunction(KeyCode.E, PickUp); // 플레이어 감지하면 픽업 사용
                    Debug.Log("플레이어를 감지!");
                    if (InputManager.Instance.KeyActions.ContainsKey(KeyCode.E) == false || InputManager.Instance.KeyActions[KeyCode.E] == NoPickup) 
                    {
                        Debug.Log("왜없음?");
                    }
                    break; // 한 방향에서 감지되면 더 이상 확인하지 않고 종료
                }
            }
            else // 만약 근처에 플레이어가 없을 경우 아이템을 줍지 못한다.
            {
                InputManager.Instance.AddFunction(KeyCode.E, NoPickup);
            }
        }
    }*/

    /*private void FixedUpdate() // 플레이어 감지할때 사용
    {
        //플레이어감지
        RaycastHit hit;                

        if (Physics.BoxCast(transform.position, 
            transform.localScale * 0.1f,
            Vector3.left * 0.1f, out hit, Quaternion.identity, 1f) ||
            Physics.BoxCast(transform.position,
            transform.localScale * 0.1f,
            Vector3.right * 0.1f, out hit, Quaternion.identity,1f)||
            Physics.BoxCast(transform.position,
            transform.localScale * 0.1f,
            Vector3.forward * 0.1f, out hit, Quaternion.identity, 1f) ||
            Physics.BoxCast(transform.position,
            transform.localScale * 0.1f,
            Vector3.back * 0.1f, out hit, Quaternion.identity, 1f))
        {
            Debug.Log("감지됨.");
            if (hit.collider.CompareTag("Player"))
            {
                InputManager.Instance.AddFunction(KeyCode.E, PickUp);
                Debug.Log("플레이어를 감지!");                
            }
        }
        else // 만약 근처에없을경우 아이템을 줍지 못한다.
        {
            InputManager.Instance.AddFunction(KeyCode.E, NoPickup);
            //Debug.Log(transform.position + " " + transform.lossyScale);
        }
    }*/
}
