using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TopDownCharacterController : MonoBehaviour
{
    #region Framework Stuff
    //Reference to attached animator
    private Animator animator;

    //Reference to attached rigidbody 2D
    private Rigidbody2D rb;

    //The direction the player is moving in
    private Vector2 playerDirection;

    //The speed at which they're moving
    private float playerSpeed = 1f;

    [Header("Movement parameters")]

    //The maximum speed the player can move
    [SerializeField] private float playerMaxSpeed = 100f;

    // Const of stamina to perfrom the roll mechanic
    public float rollStaminaCost = 20f;

    //referance to stamina sctipt
    public TopDownCharacterStamina pStamina;
    #endregion


    /// <summary>
    /// When the script first initialises this gets called, use this for grabbing componenets
    /// </summary>
    private void Awake()
    {
        //Get the attached components so we can use them later
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Called after Awake(), and is used to initialize variables e.g. set values on the player
    /// </summary>
    //private void Start()

    /// <summary>
    /// When a fixed update loop is called, it runs at a constant rate, regardless of pc perfornamce so physics can be calculated properly
    /// </summary>
    private void FixedUpdate()
    {
        //Set the velocity to the direction they're moving in, multiplied
        //by the speed they're moving
        rb.velocity = playerMaxSpeed * playerSpeed * Time.fixedDeltaTime * playerDirection;
    }

    /// <summary>
    /// When the update loop is called, it runs every frame, ca run more or less frequently depending on performance. Used to catch changes in variables or input.
    /// </summary>
    private void Update()
    {
        // read input from WASD keys
        playerDirection.x = Input.GetAxis("Horizontal");
        playerDirection.y = Input.GetAxis("Vertical");

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = (mousePosition - transform.position).normalized;


        // check if there is some movement direction, if there is something, then set animator flags and make speed = 1
        if (playerDirection.magnitude != 0)
        {
            animator.SetFloat("Horizontal", playerDirection.x);
            animator.SetFloat("Vertical", playerDirection.y);
            animator.SetFloat("Speed", playerDirection.magnitude);

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

            //Increase player speed when rolling
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_RollTree"))
            {
                playerSpeed = 2f;
            }

        }
        else
        {
            //Was the input just cancelled (released)? If so, set
            //speed to 0
            playerSpeed = 0f;

            //Update the animator too, and return
            animator.SetFloat("Speed", 0);
        }

        // Was the fire button pressed (mapped to Left mouse button or gamepad trigger)
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    public void Roll()
    {
        animator.SetTrigger("IsRolling"); 
    }


    [SerializeField] GameObject m_bulletPrefab;
    [SerializeField] Transform m_firePoint;
    [SerializeField] float m_projectileSpeed;

    // Called when the fire button is pressed to spawn and move the projectile from the player
    void Attack()
    {
        GameObject bulletToSpawn = Instantiate(m_bulletPrefab, transform.position, Quaternion.identity);

        if (bulletToSpawn.GetComponent<Rigidbody2D>() != null)
        {
            bulletToSpawn.GetComponent<Rigidbody2D>().AddForce(playerDirection.normalized * m_projectileSpeed, ForceMode2D.Impulse);
        }
    }

    





}
