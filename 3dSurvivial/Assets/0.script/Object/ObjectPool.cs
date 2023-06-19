using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;





//������ƮǮ ������ ������Ʈ(Ǯ ���� �� ) ���õ��� ������Ʈ Ǯ �� �ֽ��ϴ�.
public class ObjectPool : SingletonMono<ObjectPool>
{
    [SerializeField] ObjectClass[] objects;


    
    public Queue<ObjectClass> Objectspool = new Queue<ObjectClass>();

    public void ObjectsReturn(ObjectClass objectClass) // ������Ʈ�� ����� ������ �ٽ� �����
    {
        Objectspool.Enqueue(objectClass);
        StartCoroutine(Respon(objectClass));
    }

    public GameObject ObjectCreate()
    {
        if(Objectspool.Count <= 0)
        {
            for (int i = 0; i < 50; i++)
            {
                GameObject obj = Instantiate(objects[0].gameObject, transform);
                obj.SetActive(false);
                Objectspool.Enqueue(obj.GetComponent<ObjectClass>());
            }
            for (int i = 0; i < 50; i++)
            {
                GameObject obj = Instantiate(objects[1].gameObject, transform);
                obj.SetActive(false);
                Objectspool.Enqueue(obj.GetComponent<ObjectClass>());
            }
            for (int i = 0; i < 50; i++)
            {
                GameObject obj = Instantiate(objects[2].gameObject, transform);
                obj.SetActive(false);
                Objectspool.Enqueue(obj.GetComponent<ObjectClass>());
            }
        }
        GameObject newobj = Objectspool.Dequeue().gameObject;
        newobj.SetActive(true);
        return newobj;

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
