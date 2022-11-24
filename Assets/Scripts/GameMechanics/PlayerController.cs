using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Sprite), typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Player Variables")]
    [SerializeField] Sprite playerSprite;
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] Collider2D playerCollider;
    Gun gun;
    [SerializeField] float movementSpeed;
    [SerializeField] Transform target;
    [SerializeField] Transform inventoryTransform;
    [SerializeField] Vector3 offset;
    [SerializeField] Animator animator;

    Vector2 movement;
    bool facingRight = true;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        gun = GetComponentInChildren<Gun>();
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
        if (gun.weaponSO.weaponType == WeaponTypes.Automatic)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                gun.Shoot();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                gun.Shoot();
            }
        }
        Animate();
    }

    void FixedUpdate()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    void RotateSprite()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (mousePos.x < transform.position.x && facingRight)
        {
            Flip();
        }
        else if (mousePos.x > transform.position.x && !facingRight)
        {
            Flip();
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

        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        animator.SetFloat("BlendX", Camera.main.ScreenToViewportPoint(Input.mousePosition).x);
        animator.SetFloat("BlendY", Camera.main.ScreenToViewportPoint(Input.mousePosition).y);
    }

    void Flip()
    {
        Vector2 temporaryPos = inventoryTransform.localPosition + offset;
        temporaryPos.x = -temporaryPos.x;
        inventoryTransform.localPosition = temporaryPos;
        facingRight = !facingRight;
    }
}
