using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetFader : MonoBehaviour
{
    [SerializeField] private GameObject m_spaceObject0;
    [SerializeField] private GameObject m_spaceObject1;
    [SerializeField] private GameObject m_spaceObject2;
    [SerializeField] private GameObject m_spaceObject3;


    private int m_divisions = 3;

    float min;
    float max;

    float rangesMin;
    float range1Max;
    float range2Max;
    float range3Max;
    float range4Max;

    private void Awake()
    {
        Debug.Log("Awake");
        // this needs peak (?) positions for each planet object

        min = gameObject.GetComponent<Renderer>().bounds.min.z;
        max = gameObject.GetComponent<Renderer>().bounds.max.z;

        float width = gameObject.GetComponent<Renderer>().bounds.size.z;

        float total_length = width;

        float m_length = total_length / m_divisions;

        rangesMin = min;
        range1Max = min + m_length;
        range2Max = range1Max + m_length;
        range3Max = range2Max + m_length;
        range4Max = range3Max + m_length;
        
    }


    //private void OnCollisionEnter(Collision collision)
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("OnTriggerEnter");


        if (other.gameObject.CompareTag("Player"))
        {
            float curr_pos = other.gameObject.transform.position.z;

            if (rangesMin <= curr_pos && curr_pos < range1Max)
            {
                float modelToDimAlphaValue = DetermineAlphaValue(range1Max, rangesMin, curr_pos);

                float modelToBrightenAlphaValue = DetermineAlphaValue(rangesMin, range1Max, curr_pos);


                UpdateColor(m_spaceObject0, modelToDimAlphaValue);
                UpdateColor(m_spaceObject1, modelToBrightenAlphaValue);

                UpdateColor(m_spaceObject2, 0);
                UpdateColor(m_spaceObject3, 0);


            }
            else if (range1Max <= curr_pos && curr_pos < range2Max)
            {
                float modelToDimAlphaValue = DetermineAlphaValue(range2Max, range1Max, curr_pos);

                float modelToBrightenAlphaValue = DetermineAlphaValue(range1Max, range2Max, curr_pos);

                UpdateColor(m_spaceObject1, modelToDimAlphaValue);
                UpdateColor(m_spaceObject2, modelToBrightenAlphaValue);

                UpdateColor(m_spaceObject0, 0);
                UpdateColor(m_spaceObject3, 0);
            }
            else if (range2Max <= curr_pos && curr_pos < range3Max)
            {
                float modelToDimAlphaValue = DetermineAlphaValue(range3Max, range2Max, curr_pos);

                float modelToBrightenAlphaValue = DetermineAlphaValue(range2Max, range3Max, curr_pos);

                UpdateColor(m_spaceObject2, modelToDimAlphaValue);
                UpdateColor(m_spaceObject3, modelToBrightenAlphaValue);

                UpdateColor(m_spaceObject0, 0);
                UpdateColor(m_spaceObject1, 0);
            }
            
        }
    }

   
    private float DetermineAlphaValue(float min, float max, float currP)
    {
        float alphaValue = (currP - min) / (max - currP);

        return alphaValue;
    }

    private void UpdateColor(GameObject objectToUpdate, float alphaValue)
    {

        if (0 <= alphaValue && alphaValue <= 255)
        {
            Color m_spaceObjectMinCol = objectToUpdate.GetComponent<MeshRenderer>().materials[0].color;
            Color m_spaceObjectMinCol2 = objectToUpdate.GetComponent<MeshRenderer>().materials[1].color;

            m_spaceObjectMinCol.a = alphaValue;
            m_spaceObjectMinCol2.a = alphaValue;

            objectToUpdate.GetComponent<MeshRenderer>().materials[0].color = m_spaceObjectMinCol;
            objectToUpdate.GetComponent<MeshRenderer>().materials[1].color = m_spaceObjectMinCol;
        }
    }

}
