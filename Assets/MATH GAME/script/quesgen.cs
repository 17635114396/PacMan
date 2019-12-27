using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class bun_quesgen : MonoBehaviour
    {
    public AudioClip applause;
    public AudioClip beep;
    private AudioSource source;
    public static int n1;
    public static int n2;
    public Text tn1;
    public Text tn2;
    public Text txt_ans;
    public Text mulsym;

    public RawImage rgl;
    public RawImage rl;
    public RawImage yel;
    private int givenanswer;

    public static int answer;
    public static int marks;
    private float counter;

    // Use this for initialization
    void Start()
        {
        GetComponent<timedelay>().enabled = false;
        source = GetComponent<AudioSource>();
        //   marks = 0;

        //n1 = 0;
        //n2 = 0;
        int[] valueset1 = new int[8] { 3, 4, 5, 6, 7, 8, 9, 12 };//rmj need to exclude some values
        int[] valueset2 = new int[7] { 3, 4, 5, 6, 7, 8, 9 };
        //     int value = values[Random.Range(0, values.Length)];
        n1 = Random.Range(3, valueset1.Length);
        n2 = Random.Range(3, valueset2.Length);
        //n1 = Random.Range(3, 13);
        //n2 = Random.Range(3, 13);
        tn1.text = n1.ToString();
        tn2.text = n2.ToString();
        answer = n1 * n2;
        mulsym.text = "x";

        yel.enabled = true;
        rl.enabled = false;
        rgl.enabled = false;



        }



    public void ent_answer()
        {

        GetComponent<timedelay>().enabled = true;
        //  Debug.Log(counter);
        if (int.TryParse(txt_ans.text, out answer))
            {
            if (answer != n1 * n2)
                {

                //   marks -= 5;
                rl.enabled = true;
                rgl.enabled = false;
                yel.enabled = false;
                txt_ans.text = "";
                source.PlayOneShot(beep);
                source.loop = false;
                txt_ans.text = "";
                tn1.text = "";
                tn2.text = "";


                }
            if (answer == n1 * n2)
                {

                marks += Random.Range(40, 50);
                GetComponent<AudioSource>().Play();
                source.PlayOneShot(applause);
                source.loop = false;

                //   Debug.Log("cor" + givenanswer);

                rl.enabled = false;
                rgl.enabled = true;

                txt_ans.text = "";
                tn1.text = "";
                tn2.text = "";
                }


            }

        }
    public void cleartxt()
        {
        txt_ans.text = "";

        }




    }


