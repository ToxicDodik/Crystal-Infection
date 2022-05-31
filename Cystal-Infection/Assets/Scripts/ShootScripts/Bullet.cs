using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float lifeTime = 3f;

    [SerializeField]
    private float distance;

    [SerializeField]
    private GameObject explosiveWave;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("barrier"))
        {
         var newExplosiveWave =  Instantiate(explosiveWave, collision.collider.transform.position, Quaternion.identity);
            var anim = newExplosiveWave.GetComponent<Animator>();
            anim.SetBool("Expolisve", true);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        lifeTime -= Time.fixedDeltaTime;
        // RayCast 
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, transform.right, distance);



        //Bullet move
       
        rb.AddForce(transform.right, ForceMode2D.Impulse);
        
        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
     
      
    }
}
