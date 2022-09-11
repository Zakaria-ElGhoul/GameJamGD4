using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player Variables")]
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] Collider2D playerCollider;
    [SerializeField] float movementSpeed;
    [SerializeField] float bulletCount;
    [SerializeField] private float waitTime;
    [SerializeField] public float waitForSeconds = 5f;
    [SerializeField] Transform target;
    [SerializeField] Animator animator;
    [Space]

    [Header("Dodging mechanic // werkt nog niet")]
    [SerializeField] float dodgeSpeed = 60000;
    [SerializeField] float dodgeTime = 0.5f;
    [SerializeField] Coroutine dodging;

    Vector2 movement;
    bool facingRight = true;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        waitTime = Time.time + waitForSeconds;
    }
    void Update()
    {
        PlayerInput();
        RotateWeapon();
        RotateSprite();
    }

    void PlayerInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Animate();

        if (bulletCount <= 0)
        {
            if (Time.time > waitTime)
            {
                waitTime = Time.time + waitForSeconds;
                bulletCount = 1;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                bulletCount = 0;
                gameObject.GetComponentInChildren<Gun>().Shoot();
            }
        }

        if (Input.anyKey)
        {
            Time.timeScale = 1.0f;
        }
        else
        {
            Time.timeScale = 0.7f;
        }
    }

    void FixedUpdate()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    void RotateSprite()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (mousePos.x < transform.position.x - 1 && facingRight)
        {
            //Flip();
        }
        else if (mousePos.x > transform.position.x + 1 && !facingRight)
        {
            //Flip();
        }
    }

    void RotateWeapon()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        target.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
    void Animate()
    {
        if (movement != Vector2.zero)
        {
            animator.SetBool("IsWalking", true);
            animator.SetFloat("BlendX", movement.x);
            animator.SetFloat("BlendY", movement.y);
        }
        else
            animator.SetBool("IsWalking", false);
    }
    void Flip()
    {
        Vector3 tmpScale = transform.localScale;
        tmpScale.x = -tmpScale.x;
        transform.localScale = tmpScale;
        facingRight = !facingRight;
    }
}
