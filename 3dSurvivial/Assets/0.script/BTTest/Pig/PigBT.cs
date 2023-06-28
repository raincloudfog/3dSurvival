using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class PigBT : BehaviorTree.Tree
{
    [SerializeField]
    Animal orgpig; // µÅÁö
    [SerializeField]
    Animal pig; // µÅÁö
    Animator anim;

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
                new PigHit(pig),
                new PigRun(transform, pig)
            }),
            new PigMove(transform, pig),
            new PIgHunger(pig,anim)


        });

        return root;
    }
    
}
