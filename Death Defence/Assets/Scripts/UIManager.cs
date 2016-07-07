using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text tAmmo;
    public Text tReloading;
    public Text tNightsSurvived;
    public Text tTimeSurvived;

	void Start () {
	    
	}
	void Update () {
        if (GameManager.Instance.isReloading) tReloading.text = "Reloading...";
        else tReloading.text = null;
    }
}
