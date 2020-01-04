using UnityEngine;
using System.Collections;

public class game2over : MonoBehaviour {

    private static int total;
    public static int cut_marks;
    public static float damage;
    //private int noscore;
    //  public Text cur_score;
    //void Start()
    //    {
    //    total = newquesgen.marks-cut_marks/2;
    //    cur_score.text = total.ToString();

    //    }
    void OnCollisionEnter(Collision col)
        {
        if (col.gameObject.tag == "hitter")
            {
            damage += 0.1f;
            //   Debug.Log(damage);    
            cut_marks = questionman2.marks;
            UnityEngine.SceneManagement.SceneManager.LoadScene("game2_over");
            }

        }
    }
