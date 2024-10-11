using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    //Declaring player and x , Y corrdinates
    [SerializeField] GameObject Player;
    public float X;
    public float Y;

    //Declaring arenaManager script
    ArenaManager arenaManager;

    private void Start()
    {
        //Finding arenaManager script manually to help avoid errors
        arenaManager = GameObject.Find("ArenaController").GetComponent<ArenaManager>();
    }

    //Teleporting player to arena when touched + starting arena script
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.transform.position = new Vector2(X, Y);
            arenaManager.StartArena();
        }  
    }

}
