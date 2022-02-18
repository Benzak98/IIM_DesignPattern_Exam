using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    [SerializeField] PlayerEntity player;
    Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        player.Health.UpdateSlider += UpdateSlider;
    }

    public void UpdateSlider()
    {
        _slider.maxValue = player.Health.MaxHealth;
        _slider.value = player.Health.CurrentHealth;
    }
}
