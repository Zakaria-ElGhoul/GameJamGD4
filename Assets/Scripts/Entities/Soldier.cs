using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Entity
{
    public override bool isTargetInAttackRange()
    {
        return base.isTargetInAttackRange();
    }

    public override EnemyStates state()
    {
        return base.state();
    }

    public override EnemyStates fightStates()
    {
        return base.fightStates();
    }
    public override bool needToFlee()
    {
        return base.needToFlee();
    }

    public override bool hasDied()
    {
        return base.hasDied();
    }
    public override void ChasePlayer()
    {
        base.ChasePlayer();
    }
    public override void Attack()
    {
        base.Attack();
    }
}
