using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObsticle : MonoBehaviour
{
    [SerializeField] Transform m_StartPoint;
    [SerializeField] Transform m_EndPoint;
    [SerializeField] float Speed;

    Transform target;


    // Start is called before the first frame update
    void Start()
    {
        target = m_StartPoint;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Collision with: " + collision.gameObject.name);

        if (collision.CompareTag("MovingObstacleWaypoint"))
        {
            ChangeTarget();
        }
    }

    // Switching the target between the start and end point
    void ChangeTarget()
    {
        if (object.ReferenceEquals(target, m_StartPoint))
        {
            target = m_EndPoint;
        }
        else if (object.ReferenceEquals(target, m_EndPoint)) 
        {
           target = m_StartPoint;
        }
    }

}
