using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
[CreateAssetMenu(fileName = "New Item", menuName = "New Item/Animal")]
public class Animal : ScriptableObject
{
    //������ ���� ü��
    public int maxHp;
    //������ �¾Ҵ���
    public bool ishit;
    //������ ü��
    public int Hp;
    //������ ���
    public float Hunger;
    //������ �ӵ�
    public float speed;
    //������ �޸��� �ӵ�
    public float Runspeed;

    public Animal(Animal animal)
    {
        maxHp = animal.maxHp;
        Hp = animal.Hp;
        Hunger = animal.Hunger;
        speed = animal.speed;
        Runspeed = animal.Runspeed;
    }


}
