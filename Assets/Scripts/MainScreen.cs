using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreen : MonoBehaviour
{
    public GameObject loginPanel,MainPanel;

    public Animator SwitchPanels;

    private void Start() {
         Screen.orientation = ScreenOrientation.Portrait;
    }
  
    public void Login(){
        SwitchPanels.SetTrigger("LogIn");
    }
    public void LogOut(){
        SwitchPanels.SetTrigger("LogOut");
    }
}
