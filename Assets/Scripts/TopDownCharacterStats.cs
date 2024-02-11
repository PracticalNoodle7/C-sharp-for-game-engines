using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopDownCharacterStats1 : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;

    public float stamina;
    public float maxStamina;
    public float staminaBar;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        maxStamina = stamina;

    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        }


    }
}
