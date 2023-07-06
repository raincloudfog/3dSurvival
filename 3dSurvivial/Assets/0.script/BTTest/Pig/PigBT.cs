using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public enum NowNodeState
{
    HIt,
    Run,
    Hunger,
    Move,
    Rotate,

    End
}


public class PigBT : BehaviorTree.Tree
{
    protected NowNodeState NowNodeState;
    [SerializeField]
    Inventory inventory;
    [SerializeField]
    Animal orgpig; // ����
    [SerializeField]
    public Animal pig; // ����
    [SerializeField] Animator anim;
    [SerializeField]
    Rigidbody rigid;
    bool isdaed; // ���� �׾��°�
    
    float timer; // Ÿ�̸�
    //[SerializeField]bool ishit = false;

    protected override void Start()
    {
        pig = new Animal(orgpig);
       // pig.Hp = 5;
        base.Start();
        
    }
    protected override void Update()
    {
        pig.Hunger -= Time.deltaTime;
        timer += Time.deltaTime;
        
        base.Update();
        
    }
    protected override Node SetupBehaviorTree()
    {
        Node root = new SelectorNode(new List<Node>
        {
            new SequenceNode(new List<Node>
            {
                new IsPigDie(pig,anim),
                new Pigdie(this.gameObject, Die) // ���߿� ���� ���鶧 �׼����� �غ���.
            }),
            new SequenceNode(new List<Node>
            {
                new PigHit(pig, transform), // �ǰ� �޾Ҵٸ�
                new SequenceNode(new List<Node> // �÷��̾ ��ó��������
                {
                    new IfPlayernearPig(transform),
                    new PigRun(transform, pig, rigid) // �������� ��������
                }),
            }),
            new SequenceNode(new List<Node>
            {
                new PIgHunger(pig,anim), // ������� 
                new PigEat(pig,anim,Eat) // ��Դ´�
            }),
            new PigMoveTurn(new List<Node>
            {
                new PigMove(transform, pig, rigid,anim),// ������ �����δ�.
                new PigTurn(transform, pig), // ������ ���ʸ��� ���ƾߵȴ�
            })

        });

        return root;
    }

    public void Die()
    {
        anim.SetTrigger("PigDie");
        if(isdaed == false)
        {
            Debug.Log(isdaed + "isdead");
            ItemManager.Instance.GetMeat();
            isdaed = true;
            Debug.Log(isdaed + "isdead");
        }
        
        Destroy(this.gameObject, 1f);
    }
    
    void Eat()
    {
        anim.SetTrigger("PigEat");
        pig.Hunger += 50;
          
    }
    
    /*void test()
    {
        StartCoroutine(Testcorutine());
    }

    IEnumerator Testcorutine()
    {
        Debug.Log("�׽�Ʈ �ڷ�ƾ");
        yield break;
    }*/

}
