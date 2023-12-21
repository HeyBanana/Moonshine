using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Audio;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Slider soundEffectsSlider;
    [SerializeField] private Slider musicSlider;

    private void Awake()
    {
        soundEffectsSlider = GetComponent<Slider>();
            { 

        }
        musicSlider = GetComponent<Slider>();
            {
            
        }
    }
}
