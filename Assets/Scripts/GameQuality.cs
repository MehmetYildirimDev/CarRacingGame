using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuality : MonoBehaviour
{

    public void Low(bool quality)
    {
        if (quality)
        {
            QualitySettings.SetQualityLevel(1);//Low
        }
    }
    public void Medium(bool quality)
    {
        if (quality)
        {
            QualitySettings.SetQualityLevel(2);//Low
        }
    }

    public void High(bool quality)
    {
        if (quality)
        {
            QualitySettings.SetQualityLevel(5);//Low
        }
    }

}
