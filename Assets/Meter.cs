using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.ProceduralImage;

public class Meter : MonoBehaviour
{
    public Gradient colorGradient;

    [SerializeField] private RectTransform bar;
    private Image[] images;

    public float Value { get; set; }
    private float _maxVal;

    private void Awake()
    {
        images = GetComponentsInChildren<Image>();
        _maxVal = bar.sizeDelta.x;
        SetValue(1);
    }

    public void SetValue(float value)
    {
        Value = value;
        bar.sizeDelta = new Vector2(value * _maxVal, bar.sizeDelta.y);
        foreach (var image in images)
        {
            image.color = colorGradient.Evaluate(value);
        }
    }
    
    
}
