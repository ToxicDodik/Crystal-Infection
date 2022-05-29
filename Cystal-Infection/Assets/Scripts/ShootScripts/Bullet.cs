using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    private float speedBullet = 10f;
  
    private float lifeTime = 3f;

    [SerializeField]
    private float distance;

    

    // Update is called once per frame
    void FixedUpdate()
    {
        lifeTime -= Time.fixedDeltaTime;
        // RayCast 
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, transform.right, distance);
    
            if (raycast.collider.tag == "Enemy")
            {
                //raycast.collider.GetComponent<EnemyAI>().TakeDamage(20);
            }
        
      //Bullet move
        transform.Translate(Vector2.right * speedBullet * Time.fixedDeltaTime);

        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
     
      
    }
}
