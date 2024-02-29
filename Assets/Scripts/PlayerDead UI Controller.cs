using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadUIController : MonoBehaviour
{
    public GameObject m_PlayerDeadPanel;
    bool isPlayerDeadPanelOpen = false;

    public void OpenPlayerDeadPanel()
    {
        isPlayerDeadPanelOpen = true;
        m_PlayerDeadPanel.SetActive(isPlayerDeadPanelOpen);
    }

    public void Respawn()
    {


    }


}
