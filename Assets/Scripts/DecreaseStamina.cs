using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseStamina : MonoBehaviour
{
    public TopDownCharacterStamina pStamina;
    public float decreaseStaminaAmount;


    void Update()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Player_RollTree"))
        {
            pStamina.stamina -= decreaseStaminaAmount;
        }
    }
}
