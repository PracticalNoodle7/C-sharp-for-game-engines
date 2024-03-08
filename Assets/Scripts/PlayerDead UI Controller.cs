using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadUIController : MonoBehaviour
{
    //Declaring GameObjects and varaibales
    public GameObject m_PlayerDeadPanel;
    public bool isPlayerDeadPanelOpen;

    //Declaring other scripts and player locations + player themselves
    TopDownCharacterController characterController;
    [SerializeField] GameObject Player;
    public float x;
    public float y;

    private void Start()
    {
        //Finding player scripts manually to help avoid errors
        characterController = GameObject.Find("character").GetComponent<TopDownCharacterController>();
    }

    //Opening the death screen when player dies
    public void OpenPlayerDeadPanel()
    {
        m_PlayerDeadPanel.SetActive(isPlayerDeadPanelOpen);
    }

    //Respawning player when the respawn button is pressed
    public void Respawn()
    {
        Player.transform.position = new Vector2(x, y);
        characterController.RevivePlayer();
    }


}
