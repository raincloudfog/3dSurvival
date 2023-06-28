using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;





/// <summary>
/// �̰� ���� Ʈ���ΰ� ����.
/// </summary>
public class FollowingPlayerPetBT : BehaviorTree.Tree // UnityEngine.Tree�� ��ħ.
{
    [SerializeField]
    private Transform player; // �÷��̾��� ��ġ
    [SerializeField]
    private Transform pet;//���� ��ġ

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
