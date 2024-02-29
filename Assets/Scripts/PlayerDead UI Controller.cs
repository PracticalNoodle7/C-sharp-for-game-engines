using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadUIController : MonoBehaviour
{
    public GameObject m_PlayerDeadPanel;
    public bool isPlayerDeadPanelOpen;

    TopDownCharacterController characterController;
    [SerializeField] GameObject Player;
    public float x;
    public float y;

    private void Start()
    {
        characterController = GameObject.Find("character").GetComponent<TopDownCharacterController>();
    }

    public void OpenPlayerDeadPanel()
    {
        m_PlayerDeadPanel.SetActive(isPlayerDeadPanelOpen);
    }

    public void Respawn()
    {
        Player.transform.position = new Vector2(x, y);
        characterController.RevivePlayer();
    }


}
