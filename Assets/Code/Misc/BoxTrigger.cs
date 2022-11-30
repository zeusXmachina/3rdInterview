using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    /// <summary>
    /// Script for trigger functionality and sequences
    /// Box Trigger to hold references for all child effects.
    /// </summary>

    [SerializeField] private GameDataManager.BoxTriggerTypes boxTriggerType;
    [SerializeField] private GameSequenceManager gameSequenceManager;
    [SerializeField] private GameObject particleEffect;
    [SerializeField] private GameObject triggerTextEffect;



    // Start is called before the first frame update
    void Start()
    {
        particleEffect.SetActive(false);
        triggerTextEffect.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Sphere") {

            switch (boxTriggerType)
            {
                case GameDataManager.BoxTriggerTypes.BoxA:
                    gameSequenceManager.BoxATriggered = true;
                    particleEffect.SetActive(true);
                    triggerTextEffect.SetActive(true);
                    particleEffect.GetComponent<TrailMoveScript>().IsMoving = true;


                    break;
                case GameDataManager.BoxTriggerTypes.BoxB:
                    gameSequenceManager.BoxBTriggered = true;
                    particleEffect.SetActive(true);
                    triggerTextEffect.SetActive(true);
                    particleEffect.GetComponent<TrailMoveScript>().IsMoving = true;
                    break;
                case GameDataManager.BoxTriggerTypes.BoxC:
                    gameSequenceManager.BoxCTriggered = true;
                    particleEffect.SetActive(true);
                    GameDataManager.Instance.SetPlayerToRespawnOrigin();
                    GameDataManager.Instance.SetSphereToRespawnOrigin();
                    UIManager.Instance.SetSphereUIPosition();
                    gameSequenceManager.ResetAllTriggers();
                    break;

            }
        }

        
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Sphere")
        {

            switch (boxTriggerType)
            {
                case GameDataManager.BoxTriggerTypes.BoxA:
                    gameSequenceManager.BoxATriggered = false;
                    particleEffect.SetActive(false);
                    triggerTextEffect.SetActive(false);
                    particleEffect.GetComponent<TrailMoveScript>().IsMoving = false;


                    break;
                case GameDataManager.BoxTriggerTypes.BoxB:
                    gameSequenceManager.BoxBTriggered = false;
                    particleEffect.SetActive(false);
                    triggerTextEffect.SetActive(false);
                    particleEffect.GetComponent<TrailMoveScript>().IsMoving = false;
                    break;
                case GameDataManager.BoxTriggerTypes.BoxC:
                    //typeC exit case no required
                    particleEffect.SetActive(false);
                    break;

            }
        }


    }


}
