using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectVolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;


    private void Start()
    {
        float volume;

        

        volume = PlayerPrefs.GetFloat("effectSource");

        slider.value = volume;

        SoundManager.instance.ChangeEffectVolume(slider.value);
        slider.onValueChanged.AddListener(value => SoundManager.instance.ChangeEffectVolume(value));
    }



}
