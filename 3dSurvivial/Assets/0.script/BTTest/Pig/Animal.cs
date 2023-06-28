using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
[CreateAssetMenu(fileName = "New Item", menuName = "New Item/Animal")]
public class Animal : ScriptableObject
{
    //동물의 체력
    public int Hp;
    //동물의 허기
    public float Hunger;
    //동물의 속도
    public float speed;
    //동물의 달리기 속도
    public float Runspeed;

    public Animal(Animal animal)
    {
        Hp = animal.Hp;
        Hunger = animal.Hunger;
        speed = animal.speed;
        Runspeed = animal.Runspeed;
    }
}
