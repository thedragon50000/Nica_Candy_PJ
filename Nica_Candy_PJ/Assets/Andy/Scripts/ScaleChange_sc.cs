using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChange_sc : MonoBehaviour
{
    private float point = 1;
    public float currentPoint;
    private float minimumPoint = 0.8f;

    private bool isIncreasing;

    /// <summary>
    /// 是否到達頂峰
    /// </summary>
    private bool isMinimum;

    private Vector3 maxScale;

    void Start()
    {
        maxScale = gameObject.transform.localScale;
        currentPoint = 1;
        isIncreasing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPoint <= 0.7f)
        {
            isMinimum = true;
        }

        if (currentPoint >= 1)
        {
            isMinimum = false;
        }

        switch (isMinimum)
        {
            case true:
                isIncreasing = true;
                break;

            case false:
                isIncreasing = false;
                break;
        }

        switch (isIncreasing)
        {
            case true:
                currentPoint += 0.3f * Time.deltaTime;
                break;

            case false:
                currentPoint -= 0.5f * Time.deltaTime;
                break;
        }

        gameObject.transform.localScale = Vector3.Lerp(Vector3.zero, maxScale, currentPoint);
    }
}