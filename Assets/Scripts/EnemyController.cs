using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class EnemyController: MonoBehaviour
{
    //Variables for enemy movment
    public Transform m_Player;
    public float m_speed;
    public float m_stoppingDistance;
    bool m_PlayerInSight;

    //Variables for enemy health
    public float health;
    public float maxHealth;
    public Image healthBar;

    //enum EnemyStates { Idle, MoveToPlayer, Attack, };
   // EnemyStates m_EnemyStates;

    void Start()
    {
        //Applying the players location to a variable
        m_Player = FindObjectOfType<TopDownCharacterController>().transform;
        
        //Setting enemy's max health to their current health upon script starting
        maxHealth = health;
    }

    void Update()
    {
        //If two conditions are true then the enemy will start following the player
        if (m_PlayerInSight && Vector2.Distance(transform.position, m_Player.position) >= m_stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, m_Player.position, m_speed * Time.deltaTime);
        }       
        
        //If health bar exists it will applie the maxhealth and current health to image so it can display the health of the enemy as a graphic
        if (healthBar != null)
        {
            healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

            if (health <= 0)
            {
                Death();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If a player enters the trigger collison it will set a variable to true
        if (collision.CompareTag("Player"))
        {
            m_PlayerInSight = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if a player leaves the trigger collision it will set a variable to false
        if (collision.CompareTag("Player"))
        {
            m_PlayerInSight = false;
        }
    }

    public void DamageEnemy(float damage)
    {
        health -= damage;
    }

    public void Death()
    {
        Destroy(gameObject);
    }































}
