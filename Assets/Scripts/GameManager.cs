using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //create a singleton of the class
    public static GameManager GM_Instance = new GameManager();
    //check if we are currently fighting the boss
    public bool boss = false;
    //Get all the text objects
    public Text enemy1, enemy2, boss1, topLevel;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(EnemyManager.EM_Instance.currentEnemies[0].key);

        //get the key of both enemies to display it on the screen
        enemy1.text = EnemyManager.currentEnemies[0].key;
        enemy2.text = EnemyManager.currentEnemies[1].key;

        //check if both enemies are dead
        if(!EnemyManager.currentEnemies[0].isAlive && !EnemyManager.currentEnemies[1].isAlive)
        {
            //turn on boss
            boss = true;
        }
        //check if boss is active
        if (boss)
        {
            //remove text/key from previous enemies
            enemy1.text = "";
            enemy2.text = "";
            //display the key of the boss
            boss1.text = EnemyManager.currentBoss.key;
            //updatet the top text
            topLevel.text = "Kill the Boss!";
        }
        //check if the boss is defeated
        if(boss && !EnemyManager.currentBoss.isAlive)
        {
            //remove boss text
            boss1.text = "";
            //update the top text
            topLevel.text = "You defeated all enemies!";
        }
    }

    /// <summary>
    /// returns a random letter from the alphabet that will serve as a key for the enemy.
    /// The player will need to press that key to attack the monster
    /// </summary>
    /// <returns></returns>
    public string getRandomLetter()
    {
        //temp array that holds all the letters of the alphabet
        string[] array = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        //return a random letter from the array
        return array[Random.Range(0, array.Length)];
    }
}
