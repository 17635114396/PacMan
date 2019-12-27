using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class keepme1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
    
        {
        string scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if(scene=="sc2" || scene=="sc1")
            DontDestroyOnLoad(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
