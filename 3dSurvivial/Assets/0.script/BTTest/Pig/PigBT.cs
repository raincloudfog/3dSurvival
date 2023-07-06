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
    Animal orgpig; // 돼지
    [SerializeField]
    public Animal pig; // 돼지
    [SerializeField] Animator anim;
    [SerializeField]
    Rigidbody rigid;
    bool isdaed; // 돼지 죽었는가
    
    float timer; // 타이머
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
                new Pigdie(this.gameObject, Die) // 나중에 포폴 만들때 액션으로 해볼것.
            }),
            new SequenceNode(new List<Node>
            {
                new PigHit(pig, transform), // 피가 달았다면
                new SequenceNode(new List<Node> // 플레이어가 근처에있으면
                {
                    new IfPlayernearPig(transform),
                    new PigRun(transform, pig, rigid) // 도망간다 더빠르게
                }),
            }),
            new SequenceNode(new List<Node>
            {
                new PIgHunger(pig,anim), // 배고프면 
                new PigEat(pig,anim,Eat) // 밥먹는다
            }),
            new PigMoveTurn(new List<Node>
            {
                new PigMove(transform, pig, rigid,anim),// 돼지는 움직인다.
                new PigTurn(transform, pig), // 돼지는 몇초마다 돌아야된다
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
        Debug.Log("테스트 코루틴");
        yield break;
    }*/

}
