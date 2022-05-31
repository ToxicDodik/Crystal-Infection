using System.Collections;
using UnityEngine;

public class PC_Android_Switcher : MonoBehaviour
{
    public bool IsAndroid = false;
    public bool IsPC = true;
   
    [SerializeField] private GameObject MoveJoystick;
    [SerializeField] private GameObject ShootJoystick;


    void Start()
    {
    

        if(IsPC == true)
        {
            MoveJoystick.SetActive(false);
            ShootJoystick.SetActive(false);
        }
        else  if (IsAndroid == true)
        {
            MoveJoystick.SetActive(true);
            ShootJoystick.SetActive(true);
        }
    }

}
