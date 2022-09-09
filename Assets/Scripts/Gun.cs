using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;   
    public float bulletSpeed;
    Vector3 myScreenPos;
    public Transform gunTip;
    void Start()
    {
        myScreenPos = Camera.main.WorldToScreenPoint(this.transform.position);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletShoot = (GameObject)Instantiate(bullet, gunTip.transform.position, Quaternion.identity);
            Vector3 direction = (Input.mousePosition - myScreenPos).normalized;
            bulletShoot.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * bulletSpeed;
            Destroy(bulletShoot, 4f);
        }
    }
}
