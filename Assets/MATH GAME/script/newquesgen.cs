using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class newquesgen : MonoBehaviour
    {
    public GameObject[] num_objs;
    
 
    public static int n1;
    public static int n2;
    public Text tn1;
    public Text tn2;
    public Text txt_ans;
    public Text mulsym;
 
 
    private int givenanswer;

    public static int answer;
    public static float incorr_marks;
    public static int marks;
    private float counter;
    private int txtlength;
    private string corr_ans;
    // Use this for initialization
    void Start()
        {
     
   
        GetComponent<timedelay>().enabled = false;


     
      //  int[] valueset1 = new int[8] { 3, 4, 5, 6, 7, 8, 9, 12 };//rmj need to exclude some values
    //    int[] valueset2 = new int[6] {  4, 5, 6, 7, 8, 9 };
        //     int value = values[Random.Range(0, values.Length)];
     //   n1 = Random.Range(3, valueset1.Length);
      //  n2 = Random.Range(4, valueset2.Length);
        n1 = Random.Range(3, 13);
        n2 = Random.Range(4, 13);
        tn1.text = n1.ToString();
        tn2.text = n2.ToString();
        answer = n1 * n2;
        mulsym.text = "x";
      //  txtlength = tn1.text.Length + tn2.text.Length;
        corr_ans = answer.ToString();
        txtlength = corr_ans.Length;



        }



  //  public void ent_answer()
    void Update()
        {
     //   num_objs = GameObject.FindGameObjectsWithTag("numbers");
    //    Debug.Log(txtlength);
   //    if (num_objs.Length < 19 && )
        if(txt_ans.text.Length==txtlength)
            {

            GetComponent<timedelay>().enabled = true;
            //  Debug.Log(counter);
            if (int.TryParse(txt_ans.text, out answer))
                {
                if (answer != n1 * n2)
                    {
                    incorr_marks += 0.1f;
                    //   marks -= 5;
                   
                    //   source.PlayOneShot(beep);
                    //    source.loop = false;
                   txt_ans.text = "";
                 //   tn1.text = "";
                 //   tn2.text = "";


                    }
                if (answer == n1 * n2)
                    {

                    marks += Random.Range(40, 50);
                    GetComponent<AudioSource>().Play();
                   
                    //source.PlayOneShot(applause);
                    //source.loop = false;

                   //   Debug.Log("cor" + answer);

                    

                    txt_ans.text = "";
                    tn1.text = "";
                    tn2.text = "";
                    mulsym.text = "";
                    }


                }

            }
       //if (num_objs.Length < 18)
       //    {

       //    GetComponent<timedelay>().enabled = true;
       //    //  Debug.Log(counter);
       //    if (int.TryParse(txt_ans.text, out answer))
       //        {
       //        if (answer != n1 * n2)
       //            {
       //            incorr_marks += 0.1f;
       //            //   marks -= 5;

       //            //   source.PlayOneShot(beep);
       //            //    source.loop = false;
       //            txt_ans.text = "";
       //            //   tn1.text = "";
       //            //   tn2.text = "";


       //            }
       //        if (answer == n1 * n2)
       //            {

       //            marks += Random.Range(30, 45);
       //            GetComponent<AudioSource>().Play();

       //            //source.PlayOneShot(applause);
       //            //source.loop = false;

       //            //   Debug.Log("cor" + answer);



       //            txt_ans.text = "";
       //            tn1.text = "";
       //            tn2.text = "";
       //            mulsym.text = "";
       //            }


       //        }

       //    }
        }
    public void cleartxt()
        {
//UnityEngine.SceneManagement.SceneManager.LoadScene("sc2");
        txt_ans.text = "";
        }

    

}
