using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{
    [SerializeField] private float m_threshold = .1f;
    [SerializeField] private float m_deadZone = 0.025f;

    private bool m_isPressed;
    private Vector3 m_startPos;
    private ConfigurableJoint m_joint;

    public UnityEvent onPressed, onReleased;

    
    // Start is called before the first frame update
    void Start()
    {
        m_startPos = transform.localPosition;
        m_joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_isPressed && GetValue() + m_threshold >= 1)
            Pressed();
        if (m_isPressed && GetValue() + m_threshold <= 0)
            Released();
    }

    private float GetValue()
    {
        var value = Vector3.Distance(m_startPos, transform.localPosition) / m_joint.linearLimit.limit;

        if (Mathf.Abs(value) < m_deadZone)
            value = 0;
        return Mathf.Clamp(value, -1f, 1f);
    }


    private void Pressed()
    {
        m_isPressed = true;
        onPressed.Invoke();
        Debug.Log(message: "Pressed");
    }

    private void Released()
    {
        m_isPressed = false;
        onReleased.Invoke();
        Debug.Log(message: "Released");
    }
}
