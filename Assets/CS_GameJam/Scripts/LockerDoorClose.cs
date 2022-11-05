using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerDoorClose : MonoBehaviour
{
    [SerializeField]
    private GameObject lockerDoor;

    [SerializeField]
    private GameObject lockingTheLockerAudio;
    
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

        }

    }
}
