using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCheat : MonoBehaviour
{
    [SerializeField]
    PigBT pig;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F7))
        {
            pig.pig.Hp -= 1;
        }
    }
}
