using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;





/// <summary>
/// 이게 펫의 트리인거 같다.
/// </summary>
public class FollowingPlayerPetBT : BehaviorTree.Tree // UnityEngine.Tree와 곂침.
{
    [SerializeField]
    private Transform player; // 플레이어의 위치
    [SerializeField]
    private Transform pet;//펫의 위치

    public FollowingPlayerPetBT(Transform player, Transform pet)
    {
        this.pet = pet;
        this.player = player;
    }

    protected override Node SetupBehaviorTree()
    {
       

        Node root = new SelectorNode(new List<Node>
        {
            new SequenceNode(new List<Node>
            {
                new CheckPlayerIsNearNode(pet),
                new StayNearPlayerNode(pet)
            }),

            new GoToPlayerNode(player, pet)
        });

        return root;
    }

    //protected override void Update()
    //{
    //    base.Update();
    //    Debug.Log(SetupBehaviorTree());
    //}
}
