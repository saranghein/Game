using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hungrybar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHungry(int hungry)
    {
        slider.maxValue = hungry;
        slider.value = hungry;
    }

    public void SetHungry(int hungry)
    {
        slider.value = hungry;
    }
}
