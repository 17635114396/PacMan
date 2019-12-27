using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class scoreg2 : MonoBehaviour {
    private static int total;
    private static int loosemarks;

    public Text cur_score;
    public Text hstxt;
    public static int highscore;
  
    // Use this for initialization
    void Start()
        {
        // PlayerPrefs.DeleteAll();
        highscore = PlayerPrefs.GetInt("hsg2");
        loosemarks = game2over.cut_marks;
        hstxt.text = highscore.ToString();
        if(highscore==0)
            {
            highscore = 720;
            }
        }
    void Update()
        {

        total =questionman2.marks - loosemarks / 2;
       
        if (total > highscore)
            {
            highscore = total;
            PlayerPrefs.SetInt("hsg2", highscore);
            PlayerPrefs.Save();
           // UnityEngine.SceneManagement.SceneManager.LoadScene("win");
            Invoke("load", 1);
            } 
        }
    public void load()
        {
        UnityEngine.SceneManagement.SceneManager.LoadScene("win");
        }

    }
