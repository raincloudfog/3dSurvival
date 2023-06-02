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
        //크로스헤어의 위치를 업데이트 합니다.
        crosshairRectTransform.position = Input.mousePosition;

        //크로스헤어의 중앙 위치에서 화면 방향으로 레이캐스트를 발사합니다.
        Ray ray = mainCamera.ScreenPointToRay(crosshairRectTransform.position);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, raycastDistace))
        {
            if (hit.collider.GetComponent<ObjectClass>() == true)
                hit.collider.GetComponent<ObjectClass>().PickUp();
        }

    }
}
