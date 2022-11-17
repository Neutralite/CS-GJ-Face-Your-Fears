using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class C2GameManager : MonoBehaviour
{
    public static C2GameManager instance;
    public bool C2Active = false,
                clearFloor = false,
                C2aStarted=false,
                C2aFinished = false,
                C2bStarted=false,
                C2bFinished = false;

    [SerializeField]
    private GameObject challenge3Audio;
    [SerializeField]
    private GameObject challenge3Trigger;

    [SerializeField]
    Transform lowerFloor,waterLevel;
    Vector3 maxLower = new(0, -0.5f, 0),
            minLower = new(0,-10,0);
    Vector3 maxWater= new(0, -0.4f, 0),
            minWater= new(0, -10.1f, 0);


    [SerializeField]
    Transform[] waterPlanes;
    int usedWaterPlanes;
    public float distanceBetweenPlanes = 1;

    [SerializeField]
    MeshRenderer floor;
    [SerializeField]
    Material transparentFloor,opaqueFloor;
    Color initialFloorColor,clearFloorColor;

    [SerializeField]
    TMP_Text monitorText;
    [SerializeField]
    int timeLimit = 10;
    float remainingTime = 0;
    [SerializeField]
    bool timerStarted = false;
    public float RemainingTime
    {
        get => remainingTime;
        set 
        {
            remainingTime = value;
            monitorText.text = "Fear of " + (C2bStarted?"deep water":"heights") + " time remaining: "+ remainingTime.ToString("F1");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        lowerFloor.localPosition = maxLower;
        waterLevel.localPosition = minWater;
        usedWaterPlanes = waterPlanes.Length;
        for (int i = 0; i < waterPlanes.Length; i++)
        {
            waterPlanes[i].localPosition = new Vector3(0, -distanceBetweenPlanes * i - 2*distanceBetweenPlanes);
        }
        initialFloorColor = floor.material.color;
        clearFloorColor = initialFloorColor * new Vector4(1, 1, 1, 0);
        ClearText();
    }

    void Update()
    {
        if (C2Active && !clearFloor)
        {
            monitorText.text = "Make the floor completely transparent to continue.";
        }

        if (clearFloor && !C2aStarted)
            monitorText.text = "Lower the floor completely to continue.";
        if (C2aFinished && !C2bStarted)
            monitorText.text = "Raise the water level completely to continue.";


        if (C2aStarted && !C2aFinished)
        {
            if (!timerStarted)
            {
                ResetTime();
            }
            if (RemainingTime <= 0)
            {
                C2aFinished = true;
                ClearText();
                timerStarted = false;
            }
        }
        if (C2bStarted && !C2bFinished)
        {
            if (!timerStarted)
            {
                ResetTime();
            }
            if (RemainingTime <= 0)
            {
                C2bFinished = true;
                ClearText();
                timerStarted = false;
                
            }
        }
        if (C2bFinished)
        {

            challenge3Audio.SetActive(true);
            challenge3Trigger.SetActive(true);

        }

        DeductTime();
    }
    void ResetTime() { RemainingTime = timeLimit; timerStarted = true; }
    void DeductTime() { if (RemainingTime > 0) RemainingTime -= Time.deltaTime; }
    void ClearText() { monitorText.text = string.Empty; }
    public void UpdateFloorTransparency(float a)
    {
        floor.material = a <= 0.01 ? opaqueFloor : transparentFloor;
        floor.material.color = Color.Lerp(initialFloorColor, clearFloorColor, a);
        clearFloor = a > 0.9;
    }

    public void UpdateLowerFloor(float a)
    {
        lowerFloor.localPosition = Vector3.Lerp(maxLower,minLower,a);
        C2aStarted = a > 0.9 && clearFloor;
    }

    public void UpdateWaterLevel(float a)
    {
        waterLevel.localPosition = Vector3.Lerp(minWater, maxWater, a);
        C2bStarted = a > 0.9 && C2aFinished;
    }
}
