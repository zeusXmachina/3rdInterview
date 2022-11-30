using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;

    public enum BoxTriggerTypes { BoxA, BoxB, BoxC };
    public enum BasicStateTypes { Off, On};
    [SerializeField] private GameSequenceManager _gameSequenceManager;
    public GameSequenceManager GameSequenceManager { get { return _gameSequenceManager; } }


    [SerializeField] private Transform player;
    [SerializeField] private Transform playerRespawnPoint;
    [SerializeField] private Transform sphere;
    [SerializeField] private Transform sphereRespawnPoint;
    [SerializeField] public GameObject UIRay;
    [SerializeField] public CharacterController playerController;
    [SerializeField] public bool isMovementConstrained;
    [SerializeField] public ContinuousMoveProviderBase moveProvider;
    [SerializeField] public ContinuousTurnProviderBase turnProvider;


    [SerializeField] private UIManager _uiManager;


    [Header("Player Vars")]
    [SerializeField] private int speed;
    [SerializeField] private float turnSpeed;






    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
            Instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        isMovementConstrained = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_uiManager.isMainMenuOpen)
        {
            SetMoveConstraint(BasicStateTypes.On);
        }
        else {
            SetMoveConstraint(BasicStateTypes.Off);
        }

        if (_gameSequenceManager.BoxATriggered || _gameSequenceManager.BoxBTriggered || _gameSequenceManager.BoxCTriggered)
        {
            SetSphereUI(false);
        }
        else {

            SetSphereUI(true);
        }

    }

    public void SetPlayerToRespawnOrigin() {
        player.transform.SetPositionAndRotation(playerRespawnPoint.position, playerRespawnPoint.rotation);
    
    }
    public void SetSphereToRespawnOrigin() {
        sphere.transform.SetPositionAndRotation(sphereRespawnPoint.position, sphereRespawnPoint.rotation);
        sphere.GetComponent<Rigidbody>().velocity = Vector3.zero;
            
            }

    public void SetSphereUI(bool value) {
        if (value) { UIManager.Instance.sphereUI.SetActive(true); } else { UIManager.Instance.sphereUI.SetActive(false); }
    }

    public void SetMoveConstraint(BasicStateTypes type) {
        switch (type) {
            case BasicStateTypes.Off :
              
                moveProvider.moveSpeed = speed;
                turnProvider.turnSpeed = turnSpeed;
                isMovementConstrained = false;

                break;
            case BasicStateTypes.On:
                moveProvider.moveSpeed = 0f;
                turnProvider.turnSpeed = 0f;
                isMovementConstrained = true;
                break;
        }
    
    }

    public void LeaveGame() {
        Application.Quit();
    }
    
}
