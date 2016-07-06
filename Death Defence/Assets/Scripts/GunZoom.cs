using UnityEngine;
using System.Collections;

public class GunZoom : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(1) && !anim.GetBool("ZoomIn")) {
            anim.SetBool("ZoomIn", true);
            anim.SetBool("ZoomOut", false);
        } 

        if (Input.GetMouseButtonUp(1)) {
            anim.SetBool("ZoomOut", true);
            anim.SetBool("ZoomIn", false);
        }
    }
}
