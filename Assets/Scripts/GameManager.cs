using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager GM_Instance = new GameManager();
    public bool boss = false;
    public Text enemy1, enemy2, boss1, topLevel;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(EnemyManager.EM_Instance.currentEnemies[0].key);
        enemy1.text = EnemyManager.currentEnemies[0].key;
        enemy2.text = EnemyManager.currentEnemies[1].key;

        if(!EnemyManager.currentEnemies[0].isAlive && !EnemyManager.currentEnemies[1].isAlive)
        {
            boss = true;
        }
        if (boss)
        {
            enemy1.text = "";
            enemy2.text = "";
            boss1.text = EnemyManager.currentBoss.key;
            topLevel.text = "Kill the Boss!";
        }
        if(boss && !EnemyManager.currentBoss.isAlive)
        {
            boss1.text = "";
            topLevel.text = "You defeated all enemies!";
        }
    }

    public string getRandomLetter()
    {
        string[] array = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        return array[Random.Range(0, array.Length)];
    }
}
