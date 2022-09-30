using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyValues", order = 1)]
public class Enemy_ScriptableObj : ScriptableObject
{
    public float attackRange = 3f;
    public float maxRange = 12f;

    public float health = 100f;
    public float fleeHealth = 10f;
}
