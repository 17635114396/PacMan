using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyScoreManager : MonoBehaviour
{
    public Text ScoreText;
    public int getPoint=0;
    public int commonGetPoint;
    public int superGetpoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreLoading();
    }
    void ScoreLoading() {
        ScoreText.text = getPoint.ToString() + "分";
    }
}
