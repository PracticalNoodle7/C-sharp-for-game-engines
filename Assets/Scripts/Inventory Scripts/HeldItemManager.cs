using UnityEngine;

public class HeldItemManager : MonoBehaviour
{
    //Declaring different arrays to be used
    public EquippedSlotManager[] toolSlot;
    public EquippedSlotManager[] ArmorSlot;
    public Transform[] weaponToTransform;
    public Transform[] ArmorToTransform;

    //Declaring different gameobjects that can be transformed
    public Transform weaponManager;
    public Transform ArmorManager;
    public Transform character;

    //Checks if a tool is already equipped
    public void CheckIfToolEquipped()
    {
        //Calls a method to reset all weapon locations
        ResterWeaponLocations();

        //Goes through all weapons and checks to see if the equipped item maches the name and changes its parent + location (AKA the adoption system)
        for (int i = 0; i < toolSlot.Length; i++)
        {
            if (toolSlot[i].itemName == "BasicBullet")
            {          
                // Sets the character as the parent of basicWeaponManager and assign its position to be the same
                weaponToTransform[0].parent = character;
                weaponToTransform[0].localPosition = Vector3.zero;
            }

            if (toolSlot[i].itemName == "AssultRifle")
            {
                // Sets the character as the parent of AssultRifleWeaponManager and assign its position to be the same
                weaponToTransform[1].parent = character;
                weaponToTransform[1].localPosition = Vector3.zero;
            }

            if (toolSlot[i].itemName == "BeamWeapon")
            {
                // Sets the character as the parent of BeamWeaponManager and assign its position to be the same
                weaponToTransform[2].parent = character;
                weaponToTransform[2].localPosition = Vector3.zero;
            }
        }
    }

    //Checks if Armor is equipped
    public void CheckIfArmorEquipped()
    {
        //Calls a method to reset all weapon locations
        ResterArmorLocations();

        //Goes through all Armor and checks to see if the equipped item maches the name and changes its parent + location (AKA the adoption system)
        for (int i = 0; i < ArmorSlot.Length; i++)
        {
            if (ArmorSlot[i].itemName == "BasicArmor")
            {
                // Sets the character as the parent of basicArmorManager and assign its position to be the same
                ArmorToTransform[0].parent = character;
                ArmorToTransform[0].localPosition = Vector3.zero;
            }
            if (ArmorSlot[i].itemName == "StrongArmor")
            {
                // Sets the character as the parent of StrongArmorManager and assign its position to be the same
                ArmorToTransform[1].parent = character;
                ArmorToTransform[1].localPosition = Vector3.zero;
            }
            if (ArmorSlot[i].itemName == "UltraArmor")
            {
                // Sets the character as the parent of UltraArmorManager and assign its position to be the same
                ArmorToTransform[2].parent = character;
                ArmorToTransform[2].localPosition = Vector3.zero;
            }
            if (ArmorSlot[i].itemName == "GodlyArmor")
            {
                // Sets the character as the parent of GodlyArmorManager and assign its position to be the same
                ArmorToTransform[3].parent = character;
                ArmorToTransform[3].localPosition = Vector3.zero;
            }
        }
    }

    //Mehtod to set the weapons to the weaponManager as its parent
    public void ResterWeaponLocations()
    {
        foreach (Transform weaponTransform in weaponToTransform)
        {
            weaponTransform.parent = weaponManager;
            weaponTransform.localPosition = Vector3.zero;
        }
    }
    //Mehtod to set the Armor to the ArmorManager as its parent
    public void ResterArmorLocations()
    {
        foreach (Transform ArmorTransform in ArmorToTransform)
        {
            ArmorTransform.parent = ArmorManager;
            ArmorTransform.localPosition = Vector3.zero;
        }
    }
}

