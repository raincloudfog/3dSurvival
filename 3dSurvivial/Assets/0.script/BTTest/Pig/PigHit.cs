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
    bool IsHit; // 맞았는지 체크
    AudioClip audioClip;
    PigBT pigBT;

    public PigHit(Animal animal, Transform transform, PigBT pigBT)
    {
        pig = animal;
        CurHp = animal.Hp;
        this.transform = transform;
        //Debug.Log(CurHp);
        this.pigBT = pigBT;
    }
    
    public override NodeState Evaluate()
    {        
        if (pig.maxHp > pig.Hp)
        {
            //timer = 0;
            pig.maxHp = pig.Hp;
            IsHit = true;
            pigBT.audioSource.PlayOneShot(pigBT.audioClips[0]);
        }
        if(IsHit == true)
        {
            return NodeState.SUCCESS;
        }
        
        return NodeState.FAILURE;
    }   
}
