using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnManager : MonoBehaviour {

    public float timeBetweenRounds;
    float roundEndTimer;

    public int maxEnemies;
    public int enemyCount { get; set; }

    [Tooltip("Set this value to how many enemies you want to start with at LVL1, this will be incremented per round somehow")]
    public int enemiesPerRound;
    public float spawnRate;
    float spawnTimer;

    public Enemy[] enemies;
    public Transform[] spawnLocations;

    List<Enemy> enemiesOnScreen = new List<Enemy>();

    void Update() {
        if (!GameManager.Instance.betweenRounds) {
            int randSpawnChoice = Random.Range(0, spawnLocations.Length);
            int randEnemyChoice = Random.Range(0, enemies.Length);

            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnRate && GameManager.Instance.roundEnemyCount < maxEnemies) {
                GameObject go = Instantiate(enemies[randEnemyChoice].enemyObj, spawnLocations[randSpawnChoice].position, Quaternion.identity) as GameObject;
                go.transform.parent = transform;

                go.GetComponent<EnemyBehaviour>().enemyName = enemies[randEnemyChoice].enemyName;
                go.GetComponent<EnemyBehaviour>().enemyObj = enemies[randEnemyChoice].enemyObj;
                go.GetComponent<EnemyBehaviour>().damageToPlayer = enemies[randEnemyChoice].damageToPlayer;
                go.GetComponent<EnemyBehaviour>().damageToWalls = enemies[randEnemyChoice].damageToWalls;
                go.GetComponent<EnemyBehaviour>().hitRate = enemies[randEnemyChoice].hitRate;
                go.GetComponent<EnemyBehaviour>().health = enemies[randEnemyChoice].health;

                GameManager.Instance.roundEnemyCount++;
                spawnTimer = 0.0f;
            }
        } else {
            GameManager.Instance.roundEnemyCount = 0;
            roundEndTimer += Time.deltaTime;
            if(roundEndTimer >= timeBetweenRounds) {
                roundEndTimer = 0;
                GameManager.Instance.betweenRounds = false;
            }
        }
    }
}

[System.Serializable]
public class Enemy {
    public string enemyName;
    public GameObject enemyObj;
    public int damageToPlayer;
    public int damageToWalls;
    public float hitRate;
    public int health;
}

