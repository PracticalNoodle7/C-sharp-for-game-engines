using UnityEngine;
using UnityEngine.UI;

public class TopDownCharacterStamina : MonoBehaviour
{
    //Declaring varaibles
    public float stamina;
    public float maxStamina;
    public float regenRate = 2f;
    public Image staminaBar;

    // Start is called before the first frame update
    void Start()
    {
        //Setting staming to maxstaming amount upon spawning in
        maxStamina = stamina;
    }

    // Update is called once per frame
    void Update()
    {
        //Updating the stamina bar image based on how much stamina the player has left
        if (staminaBar != null)
        {
            staminaBar.fillAmount = Mathf.Clamp(stamina / maxStamina, 0, 1);
        }

        //Regaining stamina over time
        if (maxStamina > stamina)
        {
            stamina += regenRate * Time.deltaTime;
            stamina = Mathf.Clamp(stamina, 0f, maxStamina);
        }
      
    }
    
    //Decreasing stamina after rolling by the cost of rolling
    public void DecStaminaByRoll(float rollStaminaCost)
    {
        stamina -= rollStaminaCost;
    }
}
