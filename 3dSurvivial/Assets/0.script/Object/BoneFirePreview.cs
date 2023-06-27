using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneFirePreview : MonoBehaviour
{
    //�浹�� ������Ʈ�� �ݶ��̴�
    private List<Collider> colliderList = new List<Collider>();

    [SerializeField]
    private int layerGround; // ���� ���̾�
    private const int IGNORE_RAYCAST_LAYER = 2;

    [SerializeField]
    private Material green;
    [SerializeField]
    private Material red;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColor();
    }
    void ChangeColor()
    {
        if(colliderList.Count> 0)
        {
            SetColor(red);
            //���� ���� ����������

        }
        else
        {
            //���� ���� �ʷϻ�����
            SetColor(green);
        }
    }

    private void SetColor(Material mat)
    {
        foreach (Transform tf_Child in transform)
        {
            var newMaterials = new Material[tf_Child.GetComponent<Renderer>().materials.Length];

            for (int i = 0; i < newMaterials.Length; i++)
            {
                newMaterials[i] = mat;
            }

            tf_Child.GetComponent<Renderer>().materials = newMaterials;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer != layerGround && other.gameObject.layer != IGNORE_RAYCAST_LAYER)
            colliderList.Add(other);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != layerGround && other.gameObject.layer != IGNORE_RAYCAST_LAYER)
            colliderList.Remove(other);
    }
    
    public bool isBuildeable()
    {
        return colliderList.Count == 0;
    }

}
