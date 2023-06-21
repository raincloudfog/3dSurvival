using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spon : MonoBehaviour
{
    [SerializeField] ObjectClass[] Objects;
    
    [SerializeField] BoxCollider rangeCollider; // 박스콜라이더 크기
    // Start is called before the first frame update
    void Start()
    {
        sponer();
    }

    void sponer()
    {
        GameObject obj = ObjectPool.Instance.ObjectCreate();
        obj.transform.position = Return_randomPosition();
        int val = ObjectPool.Instance.Objectspool.Count;
        
        for (int i = 0; i <val ; i++)
        {
            Debug.Log(ObjectPool.Instance.Objectspool.Count);
            GameObject newobj = ObjectPool.Instance.ObjectCreate();
            newobj.transform.position = Return_randomPosition();
        }
    }

    Vector3 Return_randomPosition()
    {
        Vector3 originposition = transform.position;

        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, (range_X / 2));
        range_Z = Random.Range((range_Z / 2) * -1, (range_Z / 2));
        Vector3 randomPosition = new Vector3(range_X, -14f, range_Z);

        Vector3 respawnPosition = originposition + randomPosition;
        return respawnPosition;
    }


    
}
