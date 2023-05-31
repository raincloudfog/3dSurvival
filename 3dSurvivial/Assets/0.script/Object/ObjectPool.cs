using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;


//오브젝트풀 이지만 오브젝트(풀 나무 돌 ) 관련들의 오브젝트 풀 만 있습니다.
public class ObjectPool : SingletonMono<ObjectPool>
{
    Queue<ObjectClass> Objectspool = new Queue<ObjectClass>();

    public void ObjectsReturn(ObjectClass objectClass) // 오브젝트들 사용후 몇초후 다시 재등장
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
