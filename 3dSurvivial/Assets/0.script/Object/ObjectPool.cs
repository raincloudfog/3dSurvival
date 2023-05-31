using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;


//������ƮǮ ������ ������Ʈ(Ǯ ���� �� ) ���õ��� ������Ʈ Ǯ �� �ֽ��ϴ�.
public class ObjectPool : SingletonMono<ObjectPool>
{
    Queue<ObjectClass> Objectspool = new Queue<ObjectClass>();

    public void ObjectsReturn(ObjectClass objectClass) // ������Ʈ�� ����� ������ �ٽ� �����
    {
        Objectspool.Enqueue(objectClass);
        StartCoroutine(Respon(objectClass));
    }

    IEnumerator Respon(ObjectClass objectClass)
    {
        objectClass.gameObject.SetActive(false);
        yield return new WaitForSeconds(5f);
        objectClass.gameObject.SetActive(true);
        Objectspool.Dequeue();
        yield break;
    }
}
