using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractUI : MonoBehaviour
{
    public GameObject m_Press_E;
    bool isPressEVisable;
    public GameObject m_Hold_E;
    bool isHoldEVisable;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("InteractIsPressE"))
        {
            isPressEVisable = true;
            m_Press_E.SetActive(isPressEVisable);
        }
        else if(other.gameObject.CompareTag("InteractIsHoldE"))
        {
            isHoldEVisable = true;
            m_Hold_E.SetActive(isHoldEVisable);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("InteractIsPressE"))
        {
            isPressEVisable = false;
            m_Press_E.SetActive(isPressEVisable);
        }
        else if (other.gameObject.CompareTag("InteractIsHoldE"))
        {
            isHoldEVisable = false;
            m_Hold_E.SetActive(isHoldEVisable);
        }
    }





    // Update is called once per frame
    // void Update()

}
