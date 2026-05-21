using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl19 : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float value)
    {
        AudioListener.volume = value;
    }
}