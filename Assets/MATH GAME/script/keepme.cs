using UnityEngine;
using System.Collections;

public class keepme : MonoBehaviour
    {

    // Use this for initialization
    void Start()
        {
        DontDestroyOnLoad(gameObject);
        }
    }
	
	// Update is called once per frame
   