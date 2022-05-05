using System.Collections;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    SwitchingSlots switching;
    private bool canPickUp;

   public string firstSlot;
   public string secondSlot;

    private enum weopons
    {AKM, Deagle, M4A1S, Shotgun }

   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canPickUp== true)
        {
            //PickUpAKM
            if (collision.tag == weopons.AKM.ToString())
            {
                if (switching.isActiveFirstSlot == true)
                {
                    firstSlot = weopons.AKM.ToString();
                }
                else if (switching.isActiveSecendSlot == true)
                {
                    secondSlot = weopons.AKM.ToString();
                }

            }
            //PickUpDeagle

             if (collision.tag == weopons.Deagle.ToString())
            {
             if(switching.isActiveFirstSlot == true)
                {
                    firstSlot = weopons.Deagle.ToString();
                }   
             else if(switching.isActiveSecendSlot == true)
                {
                    secondSlot = weopons.Deagle.ToString();
                }
            }

            //PickUpM4A1S
             if(collision.tag == weopons.M4A1S.ToString())  
                if (switching.isActiveFirstSlot == true)
                {
                    firstSlot = weopons.M4A1S.ToString();
                }
                else if(switching.isActiveSecendSlot == true)
                {
                    secondSlot = weopons.M4A1S.ToString();
                }
                       
            }
             //PickUpShotgun
            else if(collision.tag == weopons.Shotgun.ToString())
            {
                if (switching.isActiveFirstSlot == true)
                {
                    firstSlot = weopons.Shotgun.ToString();
                }
                else if (switching.isActiveSecendSlot == true)
                {
                    secondSlot = weopons.Shotgun.ToString();
                }
            }
         }
    public void pickUpButton()
    {
        canPickUp = true;
    }
}
    

