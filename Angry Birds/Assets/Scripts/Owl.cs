using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl : Bird
{
    public bool isExplode = false;
    public GameObject EFX;
    public float Impact;
    public LayerMask LayerToHit;
    public float force = 100;
    

    //Fungsi untuk meledak
    public void Explode()
    {
        if (isExplode == false)
        {
            isExplode = true;
            GameObject EFXIns = Instantiate(EFX, transform.position, Quaternion.identity);
            Destroy(EFXIns, 10);
            Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, Impact, LayerToHit);
        
            foreach (Collider2D obj in objects)
            {
                Vector2 direction = obj.transform.position - transform.position;
                obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
            }
        }
    }

    //Dampak dari ledakan
    void OnCollisionEnter2D(Collision2D _other)
    {
        Explode();
    }
}
