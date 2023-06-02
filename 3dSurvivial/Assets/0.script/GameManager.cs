using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class GameManager : SingletonMono<GameManager>
{

    public bool isActive = false; // ��ȣ�ۿ� ����
    public float  Hp = 100; // �÷��̾� ü�� // int�� �Ϸ������� ü�� ���Ұ� �ʹ� ��������� float�� ����
    public float Hunger = 10; // �÷��̾� ���
    public float thirst = 5; // �÷��̾� ����

    private void FixedUpdate()
    {
        Hunger -= Time.deltaTime; // �ð����� ����
        thirst -= Time.deltaTime; // �ð����� ����
        if(Hunger <= 0 || thirst <= 0)
        {

            Hunger = Hunger <= 0? 0 : Hunger; // ���� ������� 0�����̸� 0���� ���� �ƴҽ� ���� ����� ��ġ
            thirst = thirst <= 0? 0 : thirst; // ���� ������ 0�����̸� 0���� ���� �ƴҽ� ���� ���� ��ġ
            Hp -= Time.deltaTime;
        }
    }
    
}
