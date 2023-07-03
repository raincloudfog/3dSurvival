using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class PigHit : Node
{
    private static int playerLayerMask = 1 << LayerMask.NameToLayer("Player");
    Animal pig;
    int CurHp;
    Transform transform;
    public PigHit(Animal animal, Transform transform)
    {
        pig = animal;
        CurHp = animal.Hp;
        this.transform = transform;
        Debug.Log(CurHp);
    }
    
    public override NodeState Evaluate()
    {        
        if (pig.maxHp > pig.Hp)
        {
            //timer = 0;
            
            return NodeState.SUCCESS;
        }
        return NodeState.FAILURE;
    }   
}
