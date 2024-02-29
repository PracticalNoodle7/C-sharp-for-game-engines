using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportPlayer : MonoBehaviour
{
    [SerializeField] GameObject Player;
    public float X;
    public float Y;

    ArenaManager arenaManager;

    private void Start()
    {
        arenaManager = GameObject.Find("ArenaController").GetComponent<ArenaManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.transform.position = new Vector2(X, Y);
            arenaManager.StartArena();
        }  
    }

}
