using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseStamina : MonoBehaviour
{
    //Declaring scripts and varaibles
    public TopDownCharacterStamina pStamina;
    public float decreaseStaminaAmount;


    void Update()
    {
        //When rolling animation is active it will decrease the stamina by the correct amount
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Player_RollTree"))
        {
            pStamina.stamina -= decreaseStaminaAmount;
        }
    }
}
