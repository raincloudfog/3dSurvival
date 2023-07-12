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
    [SerializeField]
    Inventory inventory;
    [SerializeField]
    Animal orgpig; // ����
    [SerializeField]
    public Animal pig; // ����
    //[SerializeField] Animator anim;// �ִϸ����� ���׷� �����
    [SerializeField]
    Rigidbody rigid;
    bool isdaed; // ���� �׾��°�
    public float timer;// Ÿ�̸�
    public AudioClip[] audioClips; // �����Ҹ���
    public AudioSource audioSource; // �Ҹ� ���°�

    protected override void Start()
    {
        pig = new Animal(orgpig); // ���� ������ �����س���
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
                new IsPigDie(pig),
                new Pigdie(this.gameObject, Die) // ���߿� ���� ���鶧 �׼����� �غ���.
            }),
            new SequenceNode(new List<Node>
            {
                new PigHit(pig, transform,this), // �ǰ� �޾Ҵٸ�
                new SequenceNode(new List<Node> // �÷��̾ ��ó��������
                {
                    new IfPlayernearPig(transform),
                    new PigRun(transform, pig, rigid) // �������� ��������
                }),
            }),
            new SequenceNode(new List<Node>
            {
                new PIgHunger(pig), // ������� 
                new PigEat(Eat) // ��Դ´�
            }),
            //new StopMove(rigid),
            new SelectorNode(new List<Node>
            {
                new PigMove(transform, pig, rigid,this),// ������ �����δ�.
                new PigTurn(transform, pig), // ������ ���ʸ��� ���ƾߵȴ�
            })

        });

        return root;
    }

    /// <summary>
    /// �Ǳ״� �׾����ϴ�.
    /// </summary>
    public void Die()
    {
        if (isdaed == false)
        {
            audioSource.PlayOneShot(audioClips[1]);
            Debug.Log(isdaed + "isdead");
            ItemManager.Instance.GetMeat();
            isdaed = true;
            Debug.Log(isdaed + "isdead");
        }
        // ������ƮǮ ����������� �߿����� �ʴٰ� �ǴܵǼ� ��Ʈ����
        Destroy(this.gameObject, 1f);
    }
    
    /// <summary>
    /// �Ǳ״� �Խ��ϴ�.
    /// </summary>
    void Eat()
    {
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
