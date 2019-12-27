using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class health : MonoBehaviour
    {
    public Slider hbar;
    private float damage_scrore;
    private float wrong_marks;
    private float cor_marks;
    // Use this for initialization
    void Start()
        {
        damage_scrore = gameover.damage;
        wrong_marks = newquesgen.incorr_marks;
      
        if (hbar.value < 1)
            {
            hbar.value += damage_scrore+wrong_marks;
            }
      
        }
void Update()
        {
        //if (hbar.value > 0)
        //    {
        //    hbar.value -= cor_marks;
        //    }
    if(hbar.value>0.9)
        {
        UnityEngine.SceneManagement.SceneManager.LoadScene("sc1");
        }
        }
    // Update is called once per frame
    
        }
    
