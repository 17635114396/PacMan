using UnityEngine;
using System.Collections;

public class elapsedtime : MonoBehaviour {
    public static float spenttime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    spenttime = Time.timeSinceLevelLoad;
    Debug.Log(spenttime);
	}
}
