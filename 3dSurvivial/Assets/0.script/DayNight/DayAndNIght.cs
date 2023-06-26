using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNIght : MonoBehaviour
{
    [SerializeField] private float secondPerRealTimeSecond; // 게임에서의 100초  = 현실에 1초

    private bool isNight = false;

    [SerializeField] private float fogdensityCalc; //증감량 비율

    [SerializeField] private float NightFogdensity; // 밤상태의 Fog 밀도
    private float dayFogDensity; // 낮 상태의 fog 밀도.
    private float currentFogDensity; //계산

    private void Awake()
    {
        secondPerRealTimeSecond = 100;
        dayFogDensity = RenderSettings.fogDensity;
        fogdensityCalc = 0.5f;
        NightFogdensity = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, 0.1f * secondPerRealTimeSecond * Time.deltaTime);
        if(transform.eulerAngles.x >= 170)
        {
            isNight = true;
        }
        else if(transform.eulerAngles.x >= 10)
        {
            isNight = false;
        }

        if(isNight == true)
        {
            if(currentFogDensity <= NightFogdensity)
            {
                currentFogDensity += 0.1f * fogdensityCalc * Time.deltaTime;
                RenderSettings.fogDensity = currentFogDensity;
            }
            
        }
        else
        {
            if (currentFogDensity >= dayFogDensity)
            {
                currentFogDensity -= 0.1f * fogdensityCalc * Time.deltaTime;
                RenderSettings.fogDensity = currentFogDensity;
            }
        }
    }
}
