using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI3DButtonTrigger : MonoBehaviour
{

    //TODO:

    //On trigger enter: 1. turn off challenge1 elements, 2. turn on challenge 2 element 3. play challenge 2 audio

   
    [SerializeField]
    private GameObject challenge1End;
    [SerializeField]
    private GameObject ghost;
    [SerializeField]
    private GameObject button;


    [SerializeField]
    private GameObject audioChallenge2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            button.SetActive(false);
            ghost.SetActive(false);
            challenge1End.SetActive(false);

            C2GameManager.instance.C2Active = true;

            audioChallenge2.SetActive(true);
        }
    }
}
