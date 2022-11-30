using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSequenceManager : MonoBehaviour
{


    [Header("Sequence Triggers")]
    [SerializeField] private bool boxATriggered;
    [SerializeField] private bool boxBTriggered;
    [SerializeField] private bool boxCTriggered;
    [SerializeField] private bool spherePickedUp;


    //get setters^^^
    [SerializeField] public bool BoxATriggered { get { return boxATriggered; } set { boxATriggered = value; } }
    [SerializeField] public bool BoxBTriggered { get { return boxBTriggered; } set { boxBTriggered = value; } }
    [SerializeField] public bool BoxCTriggered { get { return boxCTriggered; } set { boxCTriggered = value; } }
    [SerializeField] public bool SpherePickedUp { get { return spherePickedUp; } set { spherePickedUp = value; } }
   

   // [Header("Internal Settings")]
   // [SerializeField] private bool isOutOfBounds;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ResetAllTriggers()
    {
        BoxATriggered = false;
        BoxBTriggered = false;
        BoxCTriggered = false;
        SpherePickedUp = false;
    }



}
