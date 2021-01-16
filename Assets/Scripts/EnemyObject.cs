using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemies/BasicEnemy")]
public class EnemyObject : ScriptableObject
{
    public string name;

    public int health;
    public int magic;
    public int defense;
    public int attack;

    public string[] patterns;



}
