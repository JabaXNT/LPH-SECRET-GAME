using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestResults : MonoBehaviour
{
    public Slider slider;
    public int maxProgress;
    public static int numCorrectAnswers;

    private void Start()
    {
        slider.maxValue = maxProgress;
        slider.value = numCorrectAnswers;
    }

    public void SetProgress(int progress)
    {
        slider.value = numCorrectAnswers;
    }
}
