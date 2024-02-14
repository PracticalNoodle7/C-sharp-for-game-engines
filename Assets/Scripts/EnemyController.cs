using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyController: MonoBehaviour
{
    public Transform m_Player;
    public float m_speed;
    public float m_stoppingDistance;
    bool m_PlayerInSight = false;

    void Start()
    {
        m_Player = FindObjectOfType<TopDownCharacterController>().transform;
    }

    void Update()
    {
        if (m_PlayerInSight && Vector2.Distance(transform.position, m_Player.position) >= m_stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, m_Player.position, m_speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_PlayerInSight = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_PlayerInSight = false;
    }

}
