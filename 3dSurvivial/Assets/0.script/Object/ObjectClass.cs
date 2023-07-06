using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// �� �ڵ�� ���� �� ����ȭ�� ������ Ȯ���ϴ� �������� �ּ��� �����ϴ�.
public class ObjectClass : MonoBehaviour
{

    public Item _item; // �⺻ ������ ��;

    public Inventory inventory; // �κ��丮 ����Ȼ���

    protected Player player;
    protected Hands hands;

    //������ Ÿ�� ���� ����

    protected int Hp = 5; // ����, �ݱ� ü��;

    public virtual void PickUp() // ������ ȹ�� �߻� �Լ�
    {
    }
        
    protected void NoPickup() // �������� ���°ɷ� �ٲ��ش�.
    {
        // �ƹ��͵� �� �� ���� �ϴ� �뵵
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
                InputManager.Instance.AddFunction(KeyCode.E, PickUp); // �÷��̾� �����ϸ� �Ⱦ� ���
        }
        else if(distance > 3) // ���� ��ó�� �÷��̾ ���� ��� �������� ���� ���Ѵ�.
        {
            if(InputManager.Instance.Keyactions.ContainsKey(KeyCode.E) == false)
                InputManager.Instance.AddFunction(KeyCode.E, NoPickup);
        }
    }
    protected virtual void Init()
    {

    }
}
