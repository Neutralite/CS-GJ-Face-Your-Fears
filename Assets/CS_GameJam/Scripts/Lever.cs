using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Lever : MonoBehaviour
{
    [SerializeField]
    LeverType leverType;
    [SerializeField]
    HingeJoint joint;


    // Update is called once per frame
    void Update()
    {
        SendRotationToManager();
    }

    void SendRotationToManager()
    {

        GetComponent<Rigidbody>().freezeRotation = !C2GameManager.instance.C2Active?true:false;

        float temp = (transform.localEulerAngles.z - joint.limits.min) / (joint.limits.max - joint.limits.min);

        if (leverType == LeverType.Transparency)
        {
            C2GameManager.instance.UpdateFloorTransparency(temp);
        }
        if (leverType == LeverType.LowerFloor)
        {
            C2GameManager.instance.UpdateLowerFloor(temp);
        }
        if (leverType == LeverType.WaterLevel)
        {
            C2GameManager.instance.UpdateWaterLevel(temp);
        }
    }
}

[System.Serializable]
public enum LeverType
{
    Transparency,
    LowerFloor,
    WaterLevel,
}