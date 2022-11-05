using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 m_rotation;
    [SerializeField] private float m_speed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(m_rotation * m_speed * Time.deltaTime);
    }
}
