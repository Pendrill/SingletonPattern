using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the Boss class which inherits from the enemy class. Currently, it just has more health.
/// </summary>
public class Enemy  {
    public float health;
    public string key;
    public int level, attackPower;
    public GameObject worldRepresentation, healthBar;
    public bool isAlive;

    /// <summary>
    /// this is the Enemy constructor. It sets the health of the standard enemy and sets it isALive bool to true
    /// </summary>
	public Enemy()
    {
        health = 10;
        key = "m";
        isAlive = true;
    }

    /// <summary>
    /// More defined constructor of the Enemy
    /// </summary>
    /// <param name="Level"></param>
    /// <param name="currentEnemy"></param>
    /// <param name="position"></param>
    /// <param name="Health"></param>
    public Enemy(int Level, GameObject currentEnemy, Vector3 position, GameObject Health) : this()
    {

        level = Level;
        attackPower = 1 * level;
        key = GameManager.GM_Instance.getRandomLetter();
        worldRepresentation = GameObject.Instantiate(currentEnemy, position, Quaternion.identity);
        healthBar = Health;
       
    }

    
}
