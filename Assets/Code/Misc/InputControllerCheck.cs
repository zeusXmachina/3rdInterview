using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
public class InputControllerCheck : MonoBehaviour
{
    /// <summary>
    /// Basic Input check script designed to test for if Player is Walking
    /// </summary>

    [SerializeField] private Vector2 RightThumbstick;
    [SerializeField] private Vector2 LeftThumbstick;
    [SerializeField] private bool isWalking;
    [SerializeField] private AudioSource walkGrassSound;



    [SerializeField]
    [Tooltip("The Input System Action that will be used to read Turn data from theleft hand controller. Must be a Value Vector2 Control.")]
    InputActionProperty m_LeftHandTurnAction;
    /// <summary>
    /// The Input System Action that Unity uses to read Turn data from the left hand controller. Must be a <see cref="InputActionType.Value"/> <see cref="Vector2Control"/> Control.
    /// </summary>
    public InputActionProperty leftHandTurnAction
    {
        get => m_LeftHandTurnAction;
       
    }

    [SerializeField]
    [Tooltip("The Input System Action that will be used to read Turn data from the right hand controller. Must be a Value Vector2 Control.")]
    InputActionProperty m_RightHandTurnAction;
    /// <summary>
    /// The Input System Action that Unity uses to read Turn data from the right hand controller. Must be a <see cref="InputActionType.Value"/> <see cref="Vector2Control"/> Control.
    /// </summary>
    public InputActionProperty rightHandTurnAction
    {
        get => m_RightHandTurnAction;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RightThumbstick = ReadRightInput();
        LeftThumbstick = ReadLeftInput();
        if (LeftThumbstick.x != 0)
        {
            if (!GameDataManager.Instance.isMovementConstrained)
            {
                isWalking = true;
                if (!walkGrassSound.isPlaying)
                {
                    walkGrassSound.Play();
                } 
            }

        }
        else {
            isWalking = false;
            walkGrassSound.Stop();
        }
    }


    public Vector2 ReadRightInput()
    {
       // var leftHandValue = m_LeftHandTurnAction.action?.ReadValue<Vector2>() ?? Vector2.zero;
        var rightHandValue = m_RightHandTurnAction.action?.ReadValue<Vector2>() ?? Vector2.zero;

        return  rightHandValue;
    }
    public Vector2 ReadLeftInput()
    {        var leftHandValue = m_LeftHandTurnAction.action?.ReadValue<Vector2>() ?? Vector2.zero;
       //var rightHandValue = m_RightHandTurnAction.action?.ReadValue<Vector2>() ?? Vector2.zero;

        return leftHandValue;
    }
}
