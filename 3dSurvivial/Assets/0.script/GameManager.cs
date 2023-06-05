using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using UnityEngine.UI;

public class GameManager : SingletonMono<GameManager>
{

    public bool isActive = false; // ��ȣ�ۿ� ����
    public float  Hp = 100; // �÷��̾� ü�� // int�� �Ϸ������� ü�� ���Ұ� �ʹ� ��������� float�� ����
    public float Hunger = 100; // �÷��̾� ���
    public float thirst = 100; // �÷��̾� ����

    [SerializeField] Image[] stats; // �� ���� ���з� �̹���

    private void FixedUpdate()
    {
        MinusStat();
        statsFillmount();
    }
    /// <summary>
    /// ������ �޸� ü�� ������ �پ��
    /// </summary>
    void statsFillmount()
    {
        stats[0].fillAmount = Hp * 0.01f;
        stats[1].fillAmount = Hunger * 0.01f;
        stats[2].fillAmount = thirst * 0.01f;
    }
    /// <summary>
    /// ����� ���� ü�°���
    /// </summary>
    void MinusStat()
    {
        Hunger -= Time.deltaTime; // �ð����� ����
        thirst -= Time.deltaTime; // �ð����� ����
        if (Hunger <= 0 || thirst <= 0)
        {

            Hunger = Hunger <= 0 ? 0 : Hunger; // ���� ������� 0�����̸� 0���� ���� �ƴҽ� ���� ����� ��ġ
            thirst = thirst <= 0 ? 0 : thirst; // ���� ������ 0�����̸� 0���� ���� �ƴҽ� ���� ���� ��ġ
            Hp -= Time.deltaTime;
        }
    }
    
}
