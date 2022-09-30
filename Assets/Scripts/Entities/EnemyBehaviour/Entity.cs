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

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed;

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

        currentState = state();
        Debug.Log("State: " + currentState);

        switch (currentState)
        {
            case EnemyStates.Flee:
                fleeState?.Invoke();
                break;
            case EnemyStates.Attack:
                AttackState?.Invoke();
                break;
            case EnemyStates.Chase:
                ChaseState?.Invoke();
                break;
            case EnemyStates.Idle:
                IdleState?.Invoke();
                break;
        }
    }

    public virtual bool isTargetInAttackRange()
    {
        return rangeChecker.distanceWithTarget(currentTarget) < attackRange;
    }

    public virtual EnemyStates state()
    {
        if (rangeChecker.isInRange(currentTarget, maxRange))
        {
            return fightStates();
        }
        return EnemyStates.Idle;
    }

    public virtual EnemyStates fightStates()
    {

        if (needToFlee()) return EnemyStates.Flee;

        if (isTargetInAttackRange()) return EnemyStates.Attack;

        return EnemyStates.Chase;
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public virtual bool needToFlee()
    {
        return health <= fleeHealth;
    }

    public virtual bool hasDied()
    {
        return health <= 0;
    }

    public virtual void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.transform.position, speed * Time.deltaTime);
    }

    public virtual void Attack()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, currentTarget.transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(currentTarget.transform.forward * bulletSpeed, ForceMode2D.Impulse);
    }
}
