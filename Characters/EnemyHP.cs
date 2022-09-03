using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int health;
    private Material matBlink;
    private Material matDefault;
    private SpriteRenderer spriteRend;

    private UnityEngine.Object explosion;

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();

        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matDefault = spriteRend.material;

        explosion = Resources.Load("Explosion");
    }
    private void Update()
    {
        if(health <=0)
        {
            GameObject explosionRef = (GameObject)Instantiate(explosion);
            explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            Destroy(gameObject);
      //      GameObject explosionRef = (GameObject)Instantiate(explosion);
        //    explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        spriteRend.material = matBlink;
        Invoke("ResetMaterial", .1f);
    }
    private void ResetMaterial()
    {
        spriteRend.material = matDefault;
    }
}
