using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public Vector3 dir { get; set; }
    float bulletSpeed = 10.0f;
    Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

	void FixedUpdate () {
        rb.AddForce(dir * bulletSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
	}
}


