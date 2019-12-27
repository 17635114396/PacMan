using UnityEngine;
using System.Collections;

public class startscript : MonoBehaviour {
  
	// Use this for initialization
	void Start () {
  //  GetComponent<countdown>().enabled = false;
   
	}
	
	// Update is called once per frame
public	void startgame () {
//GetComponent<countdown>().enabled = true;
PlayerPrefs.SetInt("hs", 600);

PlayerPrefs.Save();
   UnityEngine.SceneManagement.SceneManager.LoadScene("sc2");

	}
public void startdoll()
    {
    //GetComponent<countdown>().enabled = true;
    PlayerPrefs.SetInt("hs", 600);

    PlayerPrefs.Save();
    UnityEngine.SceneManagement.SceneManager.LoadScene("doll");

    }
public void startgame2()
    {
    //GetComponent<countdown>().enabled = true;
 
    PlayerPrefs.SetInt("hsg2", 700);
    PlayerPrefs.Save();
    UnityEngine.SceneManagement.SceneManager.LoadScene("sc3");

    }
    public void exitgame()
    {
    Application.Quit();
    }
}
