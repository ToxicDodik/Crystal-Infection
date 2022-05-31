using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Sleeve : MonoBehaviour
{
    [SerializeField]
    private float lifeTime;
    [SerializeField]
    private float force;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
        var dir = transform.up + -transform.right;
        rb.gravityScale = 0;
        rb.AddForce(dir * 1F, ForceMode2D.Force);
    }
}
