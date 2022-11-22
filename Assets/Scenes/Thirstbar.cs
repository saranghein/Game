using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thistbar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxThirst(int thirst)
    {
        slider.maxValue = thirst;
        slider.value = thirst;
    }

    public void SetThist(int thirst)
    {
        slider.value = thirst;
    }
}
