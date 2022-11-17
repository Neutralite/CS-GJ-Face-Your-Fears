using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerDoorClose : MonoBehaviour
{
    [SerializeField]
    private GameObject lockerDoor;

    [SerializeField]
    private GameObject lockingTheLockerAudio;

    [SerializeField]
    private GameObject light1, light2;
    
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
        if(other.gameObject.CompareTag("Locker Door"))
        {
            Debug.Log("Door Closed");

            lockerDoor.GetComponent<Collider>().enabled = false;

            lockingTheLockerAudio.SetActive(true);

            StartCoroutine(TurnOffLights());

        }

    }

    private IEnumerator TurnOffLights()
    {
        yield return new WaitForSeconds(14);

        light1.SetActive(false);
        light2.SetActive(false);    
    }
}
