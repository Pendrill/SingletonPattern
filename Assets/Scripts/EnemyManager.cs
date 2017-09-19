using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {

    public static EnemyManager EM_Instance = new EnemyManager();
    public static Enemy[] currentEnemies = new Enemy[2];
    public GameObject[] enemiesWorld = new GameObject[2], healthBars = new GameObject[2];
    public Vector3[] enemyPositions = new Vector3[2];
    public GameObject bossWorld, healthbar3;
    public static Boss currentBoss;
    public Vector3 bossPosition;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < currentEnemies.Length; i++)
        {
            currentEnemies[i] = new Enemy(Random.Range(0, 11), enemiesWorld[i], enemyPositions[i], healthBars[i]); 
            Debug.Log(currentEnemies[i].key);
        }
	}
	
	// Update is called once per frame
	void Update () {
        //currentEnemies[1].worldRepresentation.transform.position = new Vector2(4+ Mathf.Sin(Time.deltaTime * speed), 1);
        for (int i = 0; i < currentEnemies.Length; i++)
        {
            Debug.Log(currentEnemies[i].health);
            if(currentEnemies[i].health <= 0)
            {
                currentEnemies[i].isAlive = false;
            }
        }
        if (!currentEnemies[0].isAlive)
        {
            Destroy(currentEnemies[0].worldRepresentation);
        }
        if (!currentEnemies[1].isAlive)
        {
            Destroy(currentEnemies[1].worldRepresentation);
        }
        if (!currentEnemies[0].isAlive && !currentEnemies[1].isAlive && !GameManager.GM_Instance.boss)
        {
            currentBoss = new Boss(bossWorld, bossPosition, healthbar3);
            currentBoss.healthBar.SetActive(true);
            GameManager.GM_Instance.boss = true;
        }
        else if(currentEnemies[0].isAlive || currentEnemies[1].isAlive)
        {
            if (Input.GetKeyDown(currentEnemies[0].key))
            {
                currentEnemies[0].health -= 1;
                currentEnemies[0].healthBar.GetComponent<Image>().fillAmount -= 0.1f;
                //Debug.Log(currentEnemies[0].healthBar);
            }
            else if (Input.GetKeyDown(currentEnemies[1].key)){
                currentEnemies[1].health -= 1;
                currentEnemies[1].healthBar.GetComponent<Image>().fillAmount -= 0.1f;
            }
        }
        if (GameManager.GM_Instance.boss) {

            if (currentBoss.isAlive)
            {
                if (Input.GetKeyDown(currentBoss.key)) {
                    currentBoss.health -= 1;
                    currentBoss.healthBar.GetComponent<Image>().fillAmount -= 0.032f;
                }
            }else
            {
                Destroy(currentBoss.worldRepresentation);
            }
            if (currentBoss.health <= 0)
            {
                currentBoss.isAlive = false;
            }
            
        }
   }
}
