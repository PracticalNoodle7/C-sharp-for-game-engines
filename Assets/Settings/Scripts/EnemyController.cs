using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    //Variables for enemy movment
    public Transform m_Player;
    public float m_speed;
    public float m_stoppingDistance;
    public bool m_PlayerInSight;
    public bool Attacking;


    //Variables for enemy health
    public float health;
    public float maxHealth;
    public Image healthBar;

    //Declaring Animations
    public Animator animator;
    [SerializeField] private string runningAnimationName;
    [SerializeField] private string attackAnimationName;
    [SerializeField] private string deathAnimationName;

    //Declaring other scripts
    ArenaManager arenaManager;
    ScoreSystem scoreSystem;

    void Start()
    {
        //Manually finding and attaching other scripts to help avoid any errors
        arenaManager = GameObject.Find("ArenaController").GetComponent<ArenaManager>();
        scoreSystem = GameObject.Find("scoreSystem").GetComponent<ScoreSystem>();

        //Get the attached components so we can use them later
        animator = GetComponent<Animator>();

        //Applying the players location to a variable
        m_Player = FindObjectOfType<TopDownCharacterController>().transform;
        
        //Setting enemy's max health to their current health upon script starting
        maxHealth = health;

        //Adding to the arena enemy count
        arenaManager.AddToEnemyCount();
    }

    void Update()
    {

        //Calculates the players x position relative to the enemys x position
        float PlayerPosition = m_Player.transform.position.x - transform.position.x;
        
        //Checks if player position is greater than O so they are on the right of the enemy
        if (PlayerPosition > 0)
        {
            //Flips the sprite on the x axies to face the player
            transform.localScale = new Vector2(-1, 1);
        }
        //Checks if player position is greater than O so they are on the left of the enemy
        else if (PlayerPosition < 0)
        {
            //Dosen't flip the sprite or flips it back to normal if already flipped
            transform.localScale = new Vector2(1, 1);
        }

        if (Attacking) return;

        //If two conditions are true then the enemy will start following the player
        if (m_PlayerInSight && Vector2.Distance(transform.position, m_Player.position) >= m_stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, m_Player.position, m_speed * Time.deltaTime);
            
            if (Animator.StringToHash(runningAnimationName) != 0)
            {
                animator.SetBool("inSight", true);
                animator.SetBool("inRange", false);
            }
        }
        else if(m_PlayerInSight && Vector2.Distance(transform.position, m_Player.position) <= m_stoppingDistance)
        {
            if (Animator.StringToHash(attackAnimationName) != 0)
            {
                animator.SetBool("inRange", true);
            }
        }

        
        //If health bar exists it will applie the maxhealth and current health to image so it can display the health of the enemy as a graphic
        if (healthBar != null)
        {
            healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

            if (health <= 0)
            {
                EnemyIsDead();
            }
        }
    }

    //Setting bool to true when player enters trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_PlayerInSight = true;
        }
    }

    //Setting bool to false when player leaves trigger
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if a player leaves the trigger collision it will set a variable to false
        if (collision.CompareTag("Player"))
        {
            m_PlayerInSight = false;

            if (Animator.StringToHash(runningAnimationName) != 0)
            {
                animator.SetBool("inSight", false);
            }
        }
    }

    //updating health based on damage taken
    public void DamageEnemy(float damage)
    {
        health -= damage;
    }

    //starting the death animation
    public void EnemyIsDead()
    {
        //checking if the enemy has a death animation to be perfromed
        if (Animator.StringToHash(deathAnimationName) != 0)
        {
            m_speed = 0;
            animator.SetBool("isDead", true);
        }
        else
        {
            DestroyEnemy();
        } 
    }

    //Destroying enemy and updating score and enemy count
    public void DestroyEnemy()
    {
        Destroy(gameObject);
        scoreSystem.AddScore(10);

        arenaManager.MinusFromEnemyCount();
    }































}
