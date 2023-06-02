using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreRock : ObjectClass
{
    bool ishit = false;
    public override void PickUp()
    {
        if (ishit == true || GameManager.Instance.isActive == false)
        {
            return;
        }
        Hp -= 1;
        StartCoroutine(Delay());
        Debug.Log("���� ����");
        if (Hp <= 0)
        {
            Debug.Log("���� �μ���");
            ObjectPool.Instance.ObjectsReturn(this);
        }
    }
    private void OnEnable()
    {
        Hp = 5; // ���������� ü��
        ishit = false;
    }
    IEnumerator Delay()
    {
        ishit = true;
        yield return new WaitForSeconds(0.5f);
        ishit = false;
        yield break;
    }

}
