using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class PigBT : BehaviorTree.Tree
{
    [SerializeField]
    Animal orgpig; // µÅÁö
    [SerializeField]
    public Animal pig; // µÅÁö
    Animator anim;
    [SerializeField]
    Rigidbody rigid;

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
        base.Update();
        
    }
    protected override Node SetupBehaviorTree()
    {
        Node root = new SelectorNode(new List<Node>
        {
            new SequenceNode(new List<Node>
            {
                new PigHit(pig, transform),
                new PigRun(transform, pig, rigid)
            }),
            new SequenceNode(new List<Node>
            {
                new PIgHunger(pig),
                new PigEat(pig,anim)
            }),
            new PigMove(transform, pig, rigid),
        });

        return root;
    }
    
}
