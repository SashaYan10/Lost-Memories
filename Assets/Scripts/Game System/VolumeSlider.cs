using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        slider.value = AudioManager.Instance.GetVolume();
        slider.onValueChanged.AddListener(SetVolume);
    }

    private void SetVolume(float value)
    {
        AudioManager.Instance.SetVolume(value);
    }
}
