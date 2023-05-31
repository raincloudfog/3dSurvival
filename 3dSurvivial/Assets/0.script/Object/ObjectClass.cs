using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// �� �ڵ�� ���� �� ����ȭ�� ������ Ȯ���ϴ� �������� �ּ��� �����ϴ�.
public abstract class ObjectClass : MonoBehaviour
{

    protected Player player;
    protected Hands hands;

    protected int Hp = 5; // ����, �ݱ� ü��;

    public abstract void PickUp(); // ������ ȹ�� �߻� �Լ�
    protected void NoPickup() // �������� ���°ɷ� �ٲ��ش�.
    {
        // �ƹ��͵� �� �� ���� �ϴ� �뵵
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
            InputManager.Instance.AddFunction(KeyCode.E, PickUp); // �÷��̾� �����ϸ� �Ⱦ� ���
        }
        else if(distance > 2) // ���� ��ó�� �÷��̾ ���� ��� �������� ���� ���Ѵ�.
        {
            if(InputManager.Instance.Keyactions.ContainsKey(KeyCode.E) == false)
                InputManager.Instance.AddFunction(KeyCode.E, NoPickup);
        }
    }

    /*private void FixedUpdate() 
    {
        // �밢�� ���� �迭
        Vector3[] directions = {
            Vector3.left,Vector3.right,Vector3.forward,Vector3.back,
        Vector3.left + Vector3.forward, // �»�
        Vector3.left + Vector3.back,    // ����
        Vector3.right + Vector3.forward, // ���
        Vector3.right + Vector3.back     // ����
        ,Vector3.zero
        }; // ������ ����� ������ ����. ã���� �׶� �ٲٴ� �ɷ�

        foreach (Vector3 direction in directions)
        {
            RaycastHit hit; // �÷��̾� ������

            if (Physics.BoxCast(transform.position, transform.localScale * 0.1f, direction.normalized * 0.1f, out hit, Quaternion.identity, 0.5f)) // 
            {                
                if (hit.collider.CompareTag("Player"))
                {
                    InputManager.Instance.AddFunction(KeyCode.E, PickUp); // �÷��̾� �����ϸ� �Ⱦ� ���
                    Debug.Log("�÷��̾ ����!");
                    if (InputManager.Instance.KeyActions.ContainsKey(KeyCode.E) == false || InputManager.Instance.KeyActions[KeyCode.E] == NoPickup) 
                    {
                        Debug.Log("�־���?");
                    }
                    break; // �� ���⿡�� �����Ǹ� �� �̻� Ȯ������ �ʰ� ����
                }
            }
            else // ���� ��ó�� �÷��̾ ���� ��� �������� ���� ���Ѵ�.
            {
                InputManager.Instance.AddFunction(KeyCode.E, NoPickup);
            }
        }
    }*/

    /*private void FixedUpdate() // �÷��̾� �����Ҷ� ���
    {
        //�÷��̾��
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
            Debug.Log("������.");
            if (hit.collider.CompareTag("Player"))
            {
                InputManager.Instance.AddFunction(KeyCode.E, PickUp);
                Debug.Log("�÷��̾ ����!");                
            }
        }
        else // ���� ��ó��������� �������� ���� ���Ѵ�.
        {
            InputManager.Instance.AddFunction(KeyCode.E, NoPickup);
            //Debug.Log(transform.position + " " + transform.lossyScale);
        }
    }*/
}
