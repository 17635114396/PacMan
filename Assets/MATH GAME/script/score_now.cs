using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class score_now : MonoBehaviour {

    private static int total;
    private static int loosemarks;
    public Text cur_score;
    public Text hstxt;
    public static int highscore;

  

    // Use this for initialization
    void Start()
        { 
       highscore= PlayerPrefs.GetInt("hs");
        loosemarks = gameover.cut_marks;   
        hstxt.text = highscore.ToString();
        if(highscore==0)
            {
            highscore = 612;
            hstxt.text = highscore.ToString();
            }

        }
    void Update()
        {
        total = newquesgen.marks-loosemarks/2;
        cur_score.text = total.ToString();
        if(total>highscore )
            {
            highscore = total;
            PlayerPrefs.SetInt("hs", highscore);
            PlayerPrefs.Save();
           UnityEngine.SceneManagement.SceneManager.LoadScene("win"); 
            }
        }
}
