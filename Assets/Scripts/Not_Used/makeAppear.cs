using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeAppear : MonoBehaviour
{
    [SerializeField] GameObject m_gameObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_gameObject.SetActive(true);
        }
    }
}

