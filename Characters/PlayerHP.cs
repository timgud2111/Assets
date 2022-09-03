using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    private void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();

        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matDefault = spriteRend.material;

        explosion = Resources.Load("Explosion");

        helthDisplay.text = "HP: " + health;
    }
    public int health;
    public Text helthDisplay;

    private Material matBlink;
    private Material matDefault;
    private SpriteRenderer spriteRend;

    private UnityEngine.Object explosion;
    private void Update()
    {
        if(health <=0)
        {
            GameObject explosionRef = (GameObject)Instantiate(explosion);
            explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        helthDisplay.text = "HP: " + health;
        spriteRend.material = matBlink;
        Invoke("ResetMaterial", .1f);
    }
    private void ResetMaterial()
    {
        spriteRend.material = matDefault;
    }
}
