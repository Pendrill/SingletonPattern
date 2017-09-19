using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the Boss class which inherits from the enemy class. Currently, it just has more health.
/// </summary>
public class Boss : Enemy
{
    /// <summary>
    /// Boss constructor. It takes a Gameobject which is the enemy model in the scene, a vector3 for the position of the first gameobject in the scene, 
    /// and a second gameObject which is the health bar for the player.
    /// </summary>
    /// <param name="currentEnemy"></param>
    /// <param name="position"></param>
    /// <param name="Health"></param>
    public Boss(GameObject currentEnemy, Vector3 position, GameObject Health)
    {
        health = 30;
        level = 5;
        attackPower = 10;
        //give the Boss a random letter that the player will have to press to defeat them.
        key = GameManager.GM_Instance.getRandomLetter();
        //Instantiate the enemy
        worldRepresentation = GameObject.Instantiate(currentEnemy, position, Quaternion.identity);
        //display the health bar.
        healthBar = Health;
    }
}
