using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXM;

public class TabManager : MonoBehaviour
{
    /// <summary>
    /// Script to control tabs
    /// Dynamic for multiple times of Tabs 
    /// </summary>

    [SerializeField] private int tabCount;
    [SerializeField] private GameObject tabParent;
    [SerializeField] private GameObject[] tabs;

    private void OnValidate()
    {
        for (int i = 0; i < tabs.Length; i++) {
            tabs[i].name = i.ToString();
        
        }

       SetTabState();
      
    }


    public void SetTabState(GameObject value) {

        foreach (GameObject g in tabs) {
            g.SetActive(false);
        }

        
            ZXM.TabButton tabData = value.GetComponent<ZXM.TabButton>();
            var tabIndex = tabData.tabIndex;
            tabs[tabIndex].SetActive(true);
        


    }

    public void SetTabState() {
        foreach (GameObject g in tabs)
        {
            g.SetActive(false);
        }
        tabs[0].SetActive(true);
    }

           
}
