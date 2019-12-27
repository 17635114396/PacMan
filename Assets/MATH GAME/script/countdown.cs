using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class countdown : MonoBehaviour
    {

    private float tick;
    public  Text minuits;
    public Text seconds;
    private float elap_time;
    private static int mar;
   
    // Use this for initialization
    void Start()
        {
     

       
        }

    // Update is called once per frame
    void Update()
        {
        //   mar = r3_4.r3_4marks;


       // if (SceneManager.GetActiveScene().buildIndex == 0)
         //   {
            mar = newquesgen.marks;
            tick -= Time.deltaTime;
            tick = 300 -Time.timeSinceLevelLoad;
        //    }     
        if (tick < 0)
            {

            UnityEngine.SceneManagement.SceneManager.LoadScene("win");

            }
        if (mar > 500)
            {

            UnityEngine.SceneManagement.SceneManager.LoadScene("win");
            }


        tick = Mathf.RoundToInt(tick);
        minuits.text = (Mathf.RoundToInt(tick) / 60).ToString();
        seconds.text = (tick % 60).ToString();



        // Debug.Log(mar);

        }
    }

