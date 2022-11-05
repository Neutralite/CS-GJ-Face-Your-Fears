using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
 
public class TimeBoxHandPosition : MonoBehaviour
{
    [SerializeField] private GameObject m_model1;
    [SerializeField] private GameObject m_model2;

    float m_1_pos = -0.2f;
    float m_2_pos = 0.2f;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            RectTransform rt = (RectTransform)gameObject.transform;
            float width = rt.rect.width;

            Debug.Log(collision.gameObject.transform.position);
            Vector3 pos = collision.gameObject.transform.position;

            float pos_z = pos.z;


            var val1 = Mathf.Abs(pos_z - m_1_pos);

            var val2 = Mathf.Abs(pos_z - m_2_pos);

            if (val1 < val2)
            {

            }
            else
            {

            }

        }
    }
}
