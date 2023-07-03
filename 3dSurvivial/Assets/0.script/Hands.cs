using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    Animator anim; // �ִϸ��̼�    
    [SerializeField] Player player;
    [SerializeField] ObjectClass ObjCComponent;
    [SerializeField] PigBT Pig;
    [SerializeField]public GameObject _object; // �÷��̾����� ���� ������Ʈ
    float timer = 0;
    private void Awake()
    {

    }
    private void Start()
    {
        anim = GetComponent<Animator>(); // ���߿� �����ؼ� �ν����ͷ� ���� ���� ��.
        
    }
    private void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            ActiveOn();
        }*/
        if(Input.GetMouseButton(0))
        {
            ActiveOn();
        }
        if(Input.GetMouseButtonUp(0))
        {
            ActiveOff();
        }
    }
    void ActiveOn()
    {             
        anim.SetBool("Active", true); // �����̱� �ִϸ��̼�        
        GameManager.Instance.isActive = true; // ��ȣ�ۿ���
        CheckObject();                                             
    }
    void ActiveOff()
    {
        anim.SetBool("Active", false); // �����̴� �ִϸ��̼� ��
        GameManager.Instance.isActive = false; // ��ȣ�ۿ� ��
        CheckOut();
    }
    /// <summary>
    /// ������Ʈ�� Ȯ���ϴ� �ڵ�
    /// </summary>
    void CheckObject()
    {
        timer += Time.deltaTime;
        if(player.Object == null)
        {
            //Debug.Log("�÷��̾��� ������Ʈ�� ����ֽ��ϴ�.");
            return;
        }
        _object = player.Object;

        if (_object.GetComponent<ObjectClass>() != null)
        {
            ObjCComponent = _object.GetComponent<ObjectClass>();
            ObjCComponent.PickUp();
            //Debug.Log(ObjCComponent.name);
        }
        else if(_object.GetComponent<PigBT>() == true)
        {
            Pig = _object.GetComponent<PigBT>();
            if(timer > 2)
            {
                timer = 0;
                Pig.pig.Hp -= 1;
            }
            
            //Debug.Log(Pig.pig.Hp);
        }
       


        if (ObjCComponent == null)
        {
            ObjCComponent = null;
        }
        
    }
    void CheckOut()
    {
        ObjCComponent = null;                
    }
   
}
