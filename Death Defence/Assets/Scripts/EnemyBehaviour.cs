using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
    public string enemyName { get; set; }
    public GameObject enemyObj { get; set; }
    public int damageToPlayer { get; set; }
    public int damageToWalls { get; set; }
    public float hitRate { get; set; }
    public int health { get; set; }

    public void ApplyDamage(int amount) {
        health -= amount;
        if(health <= 0) {
            Destroy(gameObject);
            GameManager.Instance.roundEnemyCount--;
        }
    }
}
