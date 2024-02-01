using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public GameObject m_Controls_Settings_Panel;
    bool isCSPanelOpen = false;

   public void LoadLevel1()
   {
        SceneManager.LoadScene("Level1");
   }

    public void OpenAndCloseSettingsPanel()
    {
        isCSPanelOpen = !isCSPanelOpen;
        m_Controls_Settings_Panel.SetActive(isCSPanelOpen);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}   
