using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskTreeProgress : MonoBehaviour
{
    [SerializeField] TMP_Text _progressText;
    [SerializeField] TaskTreeFile _file;

    private void Start()
    {
        Debug.Log("staaaart");
        var points = _file.GetValues();
        double sumCompletedPoints = 0;
        
        foreach (var point in points)
            if(point.GetIsPassed())
                sumCompletedPoints++;
        _progressText.text = Math.Round(sumCompletedPoints / points.Length * 100).ToString();
    }
}
