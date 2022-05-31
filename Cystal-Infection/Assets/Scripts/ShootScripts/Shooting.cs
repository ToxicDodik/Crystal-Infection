using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Gun Links")]

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private GameObject shootPoint;

    [SerializeField]
    private FixedJoystick joystick;

    PC_Android_Switcher switcher = new PC_Android_Switcher();
    private bool isPC;
    private bool isAndroid;

    [SerializeField]
    private GameObject sleeve;
    [SerializeField]
    private GameObject sleevePoint;

    [Header("Gun Variables")]

    [SerializeField]
    private float offset;

    [SerializeField]
    private float shotTime = 0.3f;

    [SerializeField]
    private float gunMagazineCapacity = 30;

    private float rotZ;

    private void Start()
    {
        isPC = switcher.IsPC;
        isAndroid = switcher.IsAndroid;
    }
    void Update()
    {
        shotTime -= Time.deltaTime;

        //CheckWhereToCharecterFace
        if (player.GetComponent<Transform>().localScale.x > 0)
        {
            offset = 0;

        }
        if (player.GetComponent<Transform>().localScale.x < 0)
        {
            offset = -180;
        }

        //Android GunRotation;
        if (isAndroid == true)
        {
            if (Mathf.Abs(joystick.Horizontal) > 0.3F || Mathf.Abs(joystick.Vertical) > 0.3f)
            {

                rotZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
            }
        }
        
        //PC
        
        if(isPC == true)
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            rotZ = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (shotTime <= 0)
                {
                    GameObject newBullet = Instantiate(bullet, shootPoint.transform.position, Quaternion.Euler(0, 0, rotZ));
                }
            }
        }
     
        

        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotZ + offset);


        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
         if(gunMagazineCapacity > 0)
            {
             if (shotTime <= 0)
              {
                  // Instantiate(sleeve, sleevePoint.transform.position, Quaternion.identity);
                   
                    gunMagazineCapacity--;
                    
                    shotTime = 0.3F;
                  GameObject newBullet = Instantiate(bullet, shootPoint.transform.position, Quaternion.Euler(0, 0, rotZ));
              }
            }
            else
            {
                gunMagazineCapacity = 30;
            }

        }


    }
}
   
  
     
 
      

    

