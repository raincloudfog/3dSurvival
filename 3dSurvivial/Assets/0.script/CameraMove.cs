using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform playerTransform;
    
    private void FixedUpdate()
    {
        transform.position = playerTransform.position + new Vector3(0, 0.5f, 0) ;
    }
    
}
