using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{

    public Boss(GameObject currentEnemy, Vector3 position, GameObject Health)
    {
        health = 30;
        level = 5;
        attackPower = 10;
        key = GameManager.GM_Instance.getRandomLetter();
        worldRepresentation = GameObject.Instantiate(currentEnemy, position, Quaternion.identity);
        healthBar = Health;
    }
}
