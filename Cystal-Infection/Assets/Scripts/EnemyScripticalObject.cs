using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "MyGame/Enemy Data")]
public class EnemyScripticalObject : ScriptableObject
{
    public string enemyName;
    public string description;
    public int enemyHealth;
    public int enemySpeed;
    public int enemyDamage;
    public Animator enemyAnimationController;
}
