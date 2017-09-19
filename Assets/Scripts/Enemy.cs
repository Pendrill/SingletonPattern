using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy  {
    public float health;
    public string key;
    public int level, attackPower;
    public GameObject worldRepresentation, healthBar;
    public bool isAlive;

	public Enemy()
    {
        health = 10;
        key = "m";
        isAlive = true;
    }

    public Enemy(int Level, GameObject currentEnemy, Vector3 position, GameObject Health) : this()
    {
        level = Level;
        attackPower = 1 * level;
        key = GameManager.GM_Instance.getRandomLetter();
        worldRepresentation = GameObject.Instantiate(currentEnemy, position, Quaternion.identity);
        healthBar = Health;
       
    }

    
}
