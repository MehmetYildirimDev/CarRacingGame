using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLights : MonoBehaviour
{
    public enum Side
    {
        Front,
        Back
    }

    public bool isFrontLightOn;
    public bool isBackLightOn;

    [System.Serializable]
    public struct Light
    {
        public GameObject LightObj;
        public Material LightMaterial;
        public Side side;
    }

    public Color frontLightOnColor;
    public Color frontLightOffColor;
    public Color backLightOnColor;
    public Color backLightOffColor;


    public List<Light> lights;

    private void Start()
    {
        isBackLightOn = false;
    }

    public void OperateFrontLights()
    {
        isFrontLightOn = !isFrontLightOn;

        if (isFrontLightOn)
        {
            foreach (var light in lights)
            {
                if (light.side == Side.Front && light.LightObj.activeInHierarchy == false)
                {
                    light.LightObj.SetActive(true);
                    light.LightMaterial.color = frontLightOnColor;
                }
            }
        }
        else
        {
            foreach (var light in lights)
            {
                if (light.side == Side.Front && light.LightObj.activeInHierarchy == true)
                {
                    light.LightObj.SetActive(false);
                    light.LightMaterial.color = frontLightOffColor;
                }
            }
        }
    }

    public void OperateBackLights()
    {

        if (isBackLightOn)
        {
            foreach (var light in lights)
            {
                if (light.side == Side.Back && light.LightObj.activeInHierarchy == false)
                {
                    light.LightObj.SetActive(true);
                    light.LightMaterial.color = backLightOnColor;
                }
            }
        }
        else
        {
            foreach (var light in lights)
            {
                if (light.side == Side.Back && light.LightObj.activeInHierarchy == true)
                {
                    light.LightObj.SetActive(false);
                    light.LightMaterial.color = backLightOffColor;

                }
            }
        }
    }

}
