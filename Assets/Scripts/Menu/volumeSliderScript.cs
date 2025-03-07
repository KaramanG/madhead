using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeSliderScript : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        _slider.onValueChanged.AddListener((v) =>
        {
            _audioSource.volume = v * 0.4f;            
        });
    }
}
