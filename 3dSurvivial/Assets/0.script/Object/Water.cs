using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{

    [SerializeField] private Color WaterColor; //���� ����
    [SerializeField] float waterFogDensity; // �� Ź�� ����;
    private float originDrag; // ���� �߷�
    Color originColor;
    private float originFogdensity;


    private void Start()
    {
        originColor = RenderSettings.fogColor;
        originFogdensity = RenderSettings.fogDensity;

        originDrag = 0;
    }


    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("���� ���̴� ��");
        if (other.gameObject.CompareTag("Player"))
        {
            GetWater(other);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("���� ���̴� ��");
        if (other.gameObject.CompareTag("Player"))
        {
            InputManager.Instance.AddFunction(KeyCode.E, drink);
            Debug.Log("�÷��̾� �� ������");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("���� ���̴� ��");
        if (other.gameObject.CompareTag("Player"))
        {
            GetOutWater(other);
            InputManager.Instance.AddFunction(KeyCode.E, nodrinkg);
        }
        
    }

    void drink()
    {
        Debug.Log("�����Ŵ�");
        GameManager.Instance.thirst += 10;
        if (GameManager.Instance.thirst >= 100)
        {
            GameManager.Instance.thirst = 100;
        }
        
    }

    void nodrinkg()
    {

    }

    void GetWater(Collider _player)
    {
        RenderSettings.fogColor = WaterColor;
        RenderSettings.fogDensity = waterFogDensity;
    }

    void GetOutWater(Collider _player)
    {
        RenderSettings.fogColor = originColor;
        RenderSettings.fogDensity = originFogdensity;
    }
}
