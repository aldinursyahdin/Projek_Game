using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[CreateAssetMenu]
public class Enemy : ScriptableObject
{
    public new string name;
    public GameObject Prefab;

    public int maxHealth = 100;
    public int scorePoint = 500;
    public int currentHealth;
    public bool isChase = true;
    public float speedRotation = 5f;
}
