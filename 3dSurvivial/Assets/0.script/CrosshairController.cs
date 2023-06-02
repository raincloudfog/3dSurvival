using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    public RectTransform crosshairRectTransform;
    public Camera mainCamera;
    public float raycastDistace = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ũ�ν������ ��ġ�� ������Ʈ �մϴ�.
        crosshairRectTransform.position = Input.mousePosition;

        //ũ�ν������ �߾� ��ġ���� ȭ�� �������� ����ĳ��Ʈ�� �߻��մϴ�.
        Ray ray = mainCamera.ScreenPointToRay(crosshairRectTransform.position);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, raycastDistace))
        {
            if (hit.collider.GetComponent<ObjectClass>() == true)
                hit.collider.GetComponent<ObjectClass>().PickUp();
        }

    }
}
