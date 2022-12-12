using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Entity
{
    public override bool isTargetInAttackRange => base.isTargetInAttackRange;

    public override EnemyStates state => base.state;

    public override EnemyStates fightStates => base.fightStates;

    public override void ChasePlayer() => base.ChasePlayer();
    public override void Attack() => base.Attack();

    public override void TakeDamage(float amount) => base.TakeDamage(amount);
    public override float Health { get => base.Health; set => base.Health = value; }
}
