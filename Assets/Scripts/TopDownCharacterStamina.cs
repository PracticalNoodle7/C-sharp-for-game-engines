using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;

public class TopDownCharacterStamina : MonoBehaviour
{
    public float stamina;
    public float maxStamina;
    public float regenRate = 2f;
    public Image staminaBar;

    // Start is called before the first frame update
    void Start()
    {
        maxStamina = stamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (staminaBar != null)
        {
            staminaBar.fillAmount = Mathf.Clamp(stamina / maxStamina, 0, 1);
        }

        if (maxStamina > stamina)
        {
            stamina += regenRate * Time.deltaTime;
            stamina = Mathf.Clamp(stamina, 0f, maxStamina);
        }
      
    }
    public void DecStaminaByRoll(float rollStaminaCost)
    {
        stamina -= rollStaminaCost;
    }
}
