using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticWaterLevel : MonoBehaviour
{
    [SerializeField]
    Transform dynamicWaterLevel;

    [SerializeField]
    Color baseColor;

    private void Start()
    {
        baseColor = GetComponent<MeshRenderer>().material.color;
    }
    private void Update()
    {
        UpdateColor();
    }

    private void UpdateColor()
    {
        // consider using color.lerp
        if (transform.position.y <= dynamicWaterLevel.position.y - C2GameManager.instance.distanceBetweenPlanes)
        {
            GetComponent<MeshRenderer>().material.color = baseColor;
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = Color.clear;
        }
    }
}
