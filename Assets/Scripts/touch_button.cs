using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class touch_button : MonoBehaviour
{
    public UnityEvent m_buttonPressed;
    public UnityEvent m_buttonReleased;

    public GameObject m_onOffVariable;

    [SerializeField] private Transform m_buttonMesh;
    [SerializeField] private Transform m_downTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_buttonMesh.position = m_downTransform.position;
            m_buttonPressed.Invoke();
            // test for turning VO on and off from hierarchy
            if(m_onOffVariable.activeInHierarchy == true)
            {
                m_onOffVariable.SetActive(false);
            } else
            {
                m_onOffVariable.SetActive(true);
            }
       
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_buttonMesh.localPosition = Vector3.zero;
            m_buttonReleased.Invoke();
        }
       
    }

}
