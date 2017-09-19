using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {

    //singleton of the class
    public static EnemyManager EM_Instance = new EnemyManager();
    //array of the enemies
    public static Enemy[] currentEnemies = new Enemy[2];
    //array of the enemy gamobjects, and the health bars
    public GameObject[] enemiesWorld = new GameObject[2], healthBars = new GameObject[2];
    //array of the enemy postions
    public Vector3[] enemyPositions = new Vector3[2];
    //game object for the boss and their healthbar
    public GameObject bossWorld, healthbar3;
    //boss object
    public static Boss currentBoss;
    //boss position
    public Vector3 bossPosition;
	// Use this for initialization

	void Start () {
        //create a new set of enemies and put them in the array
        for (int i = 0; i < currentEnemies.Length; i++)
        {
            currentEnemies[i] = new Enemy(Random.Range(0, 11), enemiesWorld[i], enemyPositions[i], healthBars[i]); 
            //Debug.Log(currentEnemies[i].key);
        }
	}
	
	// Update is called once per frame
	void Update () {
        //currentEnemies[1].worldRepresentation.transform.position = new Vector2(4+ Mathf.Sin(Time.deltaTime * speed), 1);
        //go through the enemies
        for (int i = 0; i < currentEnemies.Length; i++)
        {
            //check if the enemies still have health
            if(currentEnemies[i].health <= 0)
            {
                //set their bool as to whether they are alive to false
                currentEnemies[i].isAlive = false;
            }
        }
        //if the enemies are dead
        if (!currentEnemies[0].isAlive)
        {
            //destroy their gameobjects
            Destroy(currentEnemies[0].worldRepresentation);
        }
        if (!currentEnemies[1].isAlive)
        {
            Destroy(currentEnemies[1].worldRepresentation);
        }

        //if both enemies are dead and the boss is not present yet
        if (!currentEnemies[0].isAlive && !currentEnemies[1].isAlive && !GameManager.GM_Instance.boss)
        {
            //create a boss enemy
            currentBoss = new Boss(bossWorld, bossPosition, healthbar3);
            //set his healthbar to true
            currentBoss.healthBar.SetActive(true);
            //let the game manager know that the boss is here
            GameManager.GM_Instance.boss = true;
        }
        //if one of the two enmies are alive
        else if(currentEnemies[0].isAlive || currentEnemies[1].isAlive)
        {
            //if the player presses the key of the keyboard associated to the ennemy
            if (Input.GetKeyDown(currentEnemies[0].key))
            {
                //we remove heath of the enemy
                currentEnemies[0].health -= 1;
                //and we change the health bar 
                currentEnemies[0].healthBar.GetComponent<Image>().fillAmount -= 0.1f;
                //Debug.Log(currentEnemies[0].healthBar);
            }
            if (Input.GetKeyDown(currentEnemies[1].key)){
                currentEnemies[1].health -= 1;
                currentEnemies[1].healthBar.GetComponent<Image>().fillAmount -= 0.1f;
            }
        }
        //if the boss is present
        if (GameManager.GM_Instance.boss) {
            //check if the boss is alive
            if (currentBoss.isAlive)
            {
                //if the boss key is being pressed
                if (Input.GetKeyDown(currentBoss.key)) {
                    //remove some of their health and update the health bar
                    currentBoss.health -= 1;
                    currentBoss.healthBar.GetComponent<Image>().fillAmount -= 0.032f;
                }
            //destroy the boss game object
            }else
            {
                Destroy(currentBoss.worldRepresentation);
            }
            if (currentBoss.health <= 0)
            {
                //if the health is below zero, set is alive to false
                currentBoss.isAlive = false;
            }
            
        }
   }
}
