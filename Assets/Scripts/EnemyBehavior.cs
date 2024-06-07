using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyBehavior", menuName = "Enemy")]
public class EnemyBehavior : ScriptableObject
{
    public float health;
    public float damage;
    public float speed;
}
