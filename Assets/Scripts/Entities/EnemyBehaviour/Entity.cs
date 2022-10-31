using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

public class Entity : MonoBehaviour
{
    [SerializeField] private UnityEvent ChaseState;
    [SerializeField] private UnityEvent AttackState;
    [SerializeField] private UnityEvent IdleState;
    [SerializeField] private UnityEvent fleeState;

    [SerializeField] private EnemyStates currentState;

    [SerializeField] private GameObject currentTarget;

    [SerializeField] private float attackRange;
    [SerializeField] private float maxRange;

    [SerializeField] private float health;
    [SerializeField] private float fleeHealth;

    [SerializeField] private float speed;

    [SerializeField] private Enemy_ScriptableObj enemyScriptableObject;

    [SerializeField] GameObject gunPrefab;
    [SerializeField] Transform firePoint;

    [SerializeField] float waitTime;
    [SerializeField] float waitForSeconds;
    [SerializeField] float bulletCount;
    [SerializeField] float bulletSpeed;

    [SerializeField] Rigidbody2D rb;

    [SerializeField] GameObject bulletPrefab;

    private RangeChecker rangeChecker;

    void Start()
    {
        rangeChecker = GetComponent<RangeChecker>();
        currentTarget = GameObject.FindWithTag("Player");
        SetObjReference();
    }
    public void SetObjReference()
    {
        attackRange = enemyScriptableObject.attackRange;
        maxRange = enemyScriptableObject.maxRange;

        health = enemyScriptableObject.health;
        fleeHealth = enemyScriptableObject.fleeHealth;
    }

    // Update is called once per frame
    void Update()
    {
        attackRange = enemyScriptableObject.attackRange;
        maxRange = enemyScriptableObject.maxRange;

        health = enemyScriptableObject.health;
        fleeHealth = enemyScriptableObject.fleeHealth;

        currentState = state;
        Debug.Log("State: " + currentState);

        switch (currentState)
        {
            case EnemyStates.Flee:
                fleeState?.Invoke();
                break;
            case EnemyStates.Attack:
                RotateWeapon();
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
                        bulletCount = 0;
                        AttackState?.Invoke();
                }
                break;
            case EnemyStates.Chase:
                ChaseState?.Invoke();
                break;
            case EnemyStates.Idle:
                IdleState?.Invoke();
                break;
        }
    }

    public virtual bool isTargetInAttackRange => rangeChecker.distanceWithTarget(currentTarget) < attackRange;

    public virtual EnemyStates state
    {
        get
        {
            if (rangeChecker.isInRange(currentTarget, maxRange))
            {
                return fightStates;
            }
            return EnemyStates.Idle;
        }
    }

    public virtual EnemyStates fightStates
    {
        get
        {

            if (needToFlee) return EnemyStates.Flee;

            if (isTargetInAttackRange) return EnemyStates.Attack;

            return EnemyStates.Chase;
        }
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public virtual bool needToFlee => health <= fleeHealth;

    public virtual bool hasDied => health <= 0;

    public virtual void ChasePlayer()
    {
        Vector3 direction = (currentTarget.transform.position - transform.position).normalized;
        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
    }

    public virtual void Attack()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }

    public virtual void RotateWeapon()
    {
        Vector3 diff = currentTarget.transform.position - transform.position;

        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        gunPrefab.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
