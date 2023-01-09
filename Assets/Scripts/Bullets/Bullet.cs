using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isEnemyBullet;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Walls")
        {
            Destroy(this.gameObject);
        }
        else if (other.tag == "Enemies")
        {
            IDamageable damageable = other.GetComponent<IDamageable>();

            if (damageable != null && !isEnemyBullet)
            {
                damageable.TakeDamage(GameObject.Find("Player").GetComponentInChildren<PlayerGun>().damage);
                Destroy(this.gameObject);
            }
        }
        else if(other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
