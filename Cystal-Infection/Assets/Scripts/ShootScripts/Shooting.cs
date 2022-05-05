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
    private FixedJoystick joystick;

    [SerializeField]
    private GameObject shootPoint;

    [Header("Gun Variables")]

    [SerializeField]
    private float offset;

    [SerializeField]
    private float shotTime = 0.3f;

    [SerializeField]
    private float gunMagazineCapacity = 30;

    private float rotZ;
    
    void Update()
    {
        shotTime -= Time.deltaTime;

        //Gun Rotation

        if (Mathf.Abs(joystick.Horizontal) > 0.3F || Mathf.Abs(joystick.Vertical) > 0.3f)
        {

            rotZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
        }

        //CheckWhereToCharecterFace
        if (player.GetComponent<Transform>().localScale.x > 0)
        {
            offset = 0;
           
        }
        if (player.GetComponent<Transform>().localScale.x < 0)
        {
            offset = -180;
        }
           

        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotZ + offset);


        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
         if(gunMagazineCapacity > 0)
            {
             if (shotTime <= 0)
              {
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
   
  
     
 
      

    

