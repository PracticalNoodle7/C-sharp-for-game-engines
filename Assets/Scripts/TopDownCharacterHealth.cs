using UnityEngine;
using UnityEngine.UI;

public class TopDownCharacterHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float newHealth;
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        }
    }

    public void RestoreHealth(int amountToChangeStat)
    {
        newHealth = health += amountToChangeStat;
        if (newHealth < maxHealth)
        {
            health = newHealth;
        }
        else
        {
            health = maxHealth;
        }
    }
}
