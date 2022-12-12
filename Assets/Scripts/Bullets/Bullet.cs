using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Walls")
        {
            Destroy(gameObject);
        }
        else if (other.tag == "Enemies")
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(GameObject.Find("Player").GetComponentInChildren<Gun>().damage);
            }
            Destroy(gameObject);
        }
    }
}
