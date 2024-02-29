using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopDownCharacterController : MonoBehaviour
{
    #region Framework Stuff
    //Reference to attached animator
    private Animator animator;

    //Reference to attached rigidbody 2D
    private Rigidbody2D rb;

    [Header("Movement parameters")]

    //The direction the player is moving in
    private Vector2 playerDirection;

    //The speed at which they're moving
    private float playerSpeed = 1f;

    //The maximum speed the player can move
    [SerializeField] private float playerMaxSpeed = 100f;

    // Const of stamina to perfrom the roll mechanic
    public float rollStaminaCost = 20f;

    //Check if the player is alive or dead
    public bool isDead = false;

    //check if the player is rolling
    private bool isRolling = false;

    [Header("Health perameters")]

    //Declaring variables related to the players health and the image of the player health for the UI
    public float health;
    public float maxHealth;
    public float newHealth;
    public Image healthBar;


    //referance to stamina sctipt
    public TopDownCharacterStamina pStamina;
    #endregion


    private void Awake()
    {
        //Get the attached components so we can use them later
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        maxHealth = health;
    }

    private void FixedUpdate()
    {
        //Set the velocity to the direction they're moving in, multiplied
        //by the speed they're moving
        rb.velocity = playerMaxSpeed * playerSpeed * Time.fixedDeltaTime * playerDirection;
    }

    private void Update()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        }

        if (health <= 0)
        {
            PlayerIsDead();
        }

        //If the player is rolling then the update loop will stop working
        if (isDead) return;
        if (isRolling) return;

        // Get mouse position in world coordinates, Calculate direction from player to mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = (mousePosition - transform.position).normalized;

        // Read input from WASD keys
        playerDirection.x = Input.GetAxis("Horizontal");
        playerDirection.y = Input.GetAxis("Vertical");
        
        // Updates the animation perameters of the character
        if (animator != null)
        {
            animator.SetFloat("Horizontal", lookDirection.x);
            animator.SetFloat("Vertical", lookDirection.y); 
            animator.SetFloat("Speed", playerDirection.magnitude);
        }

        // check if there is some movement direction, if there is something, then set animator flags and make speed = 1
        if (playerDirection.magnitude != 0)
        {
            //And set the speed to 1, so they move!
            playerSpeed = 1f;

            //Have they pressed the "SpaceBar" down? If so, check if they have enough stamina. If they do then exicure roll funcition
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (pStamina.stamina >= rollStaminaCost)
                {
                    pStamina.DecStaminaByRoll(rollStaminaCost);
                    Roll();
                }
                else
                {
                    Debug.Log("Not enough stamina to roll!");
                }
            }
        }
        else
        {
            //Was the input just cancelled (released)? If so set speed to 0
            playerSpeed = 0f;

            //Update the animator too, and return
            animator.SetFloat("Speed", 0);
        }
    }

    public void RestoreHealth(int amountToChangeStat)
    {
        newHealth = health += amountToChangeStat;
        if (newHealth < maxHealth)
        {
            health = newHealth;
        }
        else
        {
            health = maxHealth;
        }
    }

    //Method for when the player is dead
    private void PlayerIsDead()
    {
        isDead = true;
        playerSpeed = 0f;

    }

    private void LateUpdate()
    {
        //Increase player speed when rolling
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_RollTree"))
        {
            playerSpeed = 2f;
        }
    }

    // Changes the player animation to rolling when called
    public void Roll()
    {
        isRolling = true;
        animator.SetTrigger("IsRolling");

        // Get the duration of the roll animation
        float rollDuration = 0.9f;

        //Invoking a method to reset isRolling to false after the roll is completed based on a duration
        Invoke(nameof(ResetRollingFlag), rollDuration);
    }
    
    // Reset isRolling to false to allow player movement again
    private void ResetRollingFlag()
    {
        isRolling = false;
    }
}
