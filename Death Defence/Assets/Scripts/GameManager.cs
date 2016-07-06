using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    private static GameManager instance;
    public static GameManager Instance {
        get {
            if (instance == null) {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }

            return instance;
        }
    }

    public int score { get; set; }
    public int day { get; set; }
    public int enemiesKilled { get; set; }
    public int roundEnemyCount { get; set; }
    public float timeAlive { get; set; }
    public bool isDead { get; set; }
    public bool betweenRounds { get; set; }
    public bool isReloading { get; set; }

    void Awake() {
        instance = this;
        betweenRounds = false;
        isReloading = false;
    }
}
