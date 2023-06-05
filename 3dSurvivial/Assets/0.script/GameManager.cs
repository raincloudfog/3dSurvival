using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using UnityEngine.UI;

public class GameManager : SingletonMono<GameManager>
{

    public bool isActive = false; // 상호작용 가능
    public float  Hp = 100; // 플레이어 체력 // int로 하려했으나 체력 감소가 너무 빠른관계로 float로 변경
    public float Hunger = 100; // 플레이어 허기
    public float thirst = 100; // 플레이어 갈증

    [SerializeField] Image[] stats; // 피 음식 수분량 이미지

    private void FixedUpdate()
    {
        MinusStat();
        statsFillmount();
    }
    /// <summary>
    /// 스탯이 달면 체력 아이콘 줄어듬
    /// </summary>
    void statsFillmount()
    {
        stats[0].fillAmount = Hp * 0.01f;
        stats[1].fillAmount = Hunger * 0.01f;
        stats[2].fillAmount = thirst * 0.01f;
    }
    /// <summary>
    /// 배고픔 갈증 체력감소
    /// </summary>
    void MinusStat()
    {
        Hunger -= Time.deltaTime; // 시간마다 감소
        thirst -= Time.deltaTime; // 시간마다 감소
        if (Hunger <= 0 || thirst <= 0)
        {

            Hunger = Hunger <= 0 ? 0 : Hunger; // 만약 배고픔이 0이하이면 0으로 고정 아닐시 현재 배고픔 수치
            thirst = thirst <= 0 ? 0 : thirst; // 만약 갈증이 0이하이면 0으로 고정 아닐시 현재 갈증 수치
            Hp -= Time.deltaTime;
        }
    }
    
}
