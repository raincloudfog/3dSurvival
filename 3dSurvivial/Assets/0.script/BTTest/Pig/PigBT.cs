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
    Animal orgpig; // 돼지
    [SerializeField]
    public Animal pig; // 돼지
    //[SerializeField] Animator anim;// 애니메이터 버그로 취소함
    [SerializeField]
    Rigidbody rigid;
    bool isdaed; // 돼지 죽었는가
    public float timer;// 타이머
    public AudioClip[] audioClips; // 돼지소리들
    public AudioSource audioSource; // 소리 쓰는곳

    protected override void Start()
    {
        pig = new Animal(orgpig); // 원래 돼지를 복사해놓기
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
                new Pigdie(this.gameObject, Die) // 나중에 포폴 만들때 액션으로 해볼것.
            }),
            new SequenceNode(new List<Node>
            {
                new PigHit(pig, transform,this), // 피가 달았다면
                new SequenceNode(new List<Node> // 플레이어가 근처에있으면
                {
                    new IfPlayernearPig(transform),
                    new PigRun(transform, pig, rigid) // 도망간다 더빠르게
                }),
            }),
            new SequenceNode(new List<Node>
            {
                new PIgHunger(pig), // 배고프면 
                new PigEat(Eat) // 밥먹는다
            }),
            //new StopMove(rigid),
            new SelectorNode(new List<Node>
            {
                new PigMove(transform, pig, rigid,this),// 돼지는 움직인다.
                new PigTurn(transform, pig), // 돼지는 몇초마다 돌아야된다
            })

        });

        return root;
    }

    /// <summary>
    /// 피그는 죽었습니다.
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
        // 오브젝트풀 사용할정도로 중요하지 않다고 판단되서 디스트로이
        Destroy(this.gameObject, 1f);
    }
    
    /// <summary>
    /// 피그는 먹습니다.
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
        Debug.Log("테스트 코루틴");
        yield break;
    }*/

}
