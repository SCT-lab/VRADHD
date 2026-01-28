
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class ChangeVolumeSlider : UdonSharpBehaviour
{
    public AudioSource[] audioSource2;
    public UnityEngine.UI.Slider slider;

    private void Start()
    {
        foreach(var audioSource in audioSource2)
        {
            audioSource.volume = slider.value;
        }
        
    }

    public void OnVolumeChanged()
    {
        float newValue = slider.value;

        foreach(var audioSource in audioSource2)
        {
            audioSource.volume = newValue;
        }
        
    }
}
