using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class VolumeSlider : MonoBehaviour
{
    private enum VolumeType
    {
        Master,
        SFX
    }
    [Header("Type")]
    [SerializeField]
    private VolumeType type;

    
    public Slider slider;

    private void Update()
    {
        switch (type)
        {
            case VolumeType.Master: slider.value = AudioManager.Instance.masteVolume;  break;
            default : break;
        }
    }

    public void OnSliderValueChanged()
    {
        switch (type)
        {
            case VolumeType.Master: AudioManager.Instance.masteVolume = slider.value; break;
            default: break;
        }
    }
}
