using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwitchingSlots : MonoBehaviour
{
    Inventory inventory;

    private Button switchButton;

    public bool isActiveFirstSlot;
    public bool isActiveSecendSlot;
  
    
    private void Start()
    {
        isActiveFirstSlot = true;
        isActiveSecendSlot = false;

        switchButton.onClick.AddListener(SwitchingGuns);
    }

    private void SwitchingGuns()
    {
        if (isActiveFirstSlot == true)
        {
            isActiveFirstSlot = false;
            isActiveSecendSlot = true;
        }
        else
        {
            isActiveSecendSlot = false;
            isActiveFirstSlot = true;
        } 
    }
}
