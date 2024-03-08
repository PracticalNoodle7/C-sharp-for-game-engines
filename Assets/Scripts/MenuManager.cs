using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    //Declaring GameObjects and varaibles
    public GameObject m_Controls_Settings_Panel;
    bool isCSPanelOpen = false;

    //Loading level 1 when called
   public void LoadLevel1()
   {
        SceneManager.LoadScene("Level1");
   }

    //Updating settings panel depending if it is closed or open
    public void OpenAndCloseSettingsPanel()
    {
        isCSPanelOpen = !isCSPanelOpen;
        m_Controls_Settings_Panel.SetActive(isCSPanelOpen);
    }
    
    //Closing the game when called
    public void Quit()
    {
        Application.Quit();
    }
}   
