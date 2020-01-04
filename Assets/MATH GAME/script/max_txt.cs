using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class max_txt : MonoBehaviour
    {
    public Text answer;
    // Use this for initialization


    // Update is called once per frame
    void Update()
        {
        if (answer.text.Length > 3)
            {
            answer.text = "";
            }
        
        }
}
