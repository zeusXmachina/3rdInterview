using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;



    [Header("UI Triggers")]
    [SerializeField] public bool isMainMenuOpen;
    [SerializeField] public GameObject mainMenuUI;
    [SerializeField] public GameObject sphereUI;
    [SerializeField] public Transform sphereTransform;

    [SerializeField] private float range;

    [SerializeField] private bool sphereUIStart;

    [SerializeField] private AudioSource hoverAudio;
    [SerializeField] private AudioSource clickAudio;
    [SerializeField] private AudioSource closeAudio;



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
        isMainMenuOpen = mainMenuUI.activeInHierarchy;
        GameDataManager.Instance.UIRay.SetActive(isMainMenuOpen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleMainMenuUI() {
        if (mainMenuUI.activeInHierarchy)
        {
            mainMenuUI.SetActive(false);
            isMainMenuOpen = false;
            GameDataManager.Instance.UIRay.SetActive(false);

        }
        else {
            mainMenuUI.SetActive(true);
            isMainMenuOpen = true;
            GameDataManager.Instance.UIRay.SetActive(true);

        }
    
    }

    public void SetSphereUIPosition()
    {
        sphereUI.SetActive(true);
       
        Vector3 newPos = new Vector3(
            sphereTransform.position.x + range,
            0.5f,
            sphereTransform.position.z

            ) ;
        sphereUI.transform.position = newPos;
        
    }

    public void HideSphereUI() {
        sphereUI.SetActive(false);
        Debug.Log("Sphere UI Deactivated");
    
    }

    public void PlayHoverAudio() {

        hoverAudio.Play();
    } 
    public void PlayClickAudio() {

        clickAudio.Play();
    }

    public void PlayCloseAudio() {
        closeAudio.Play();
    
    }


}
