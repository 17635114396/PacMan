using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuWuManager : MonoBehaviour
{
    GameObject gameMode;//传递游戏模式
    public float speed;//旋转速度
    public bool pos;
    GameObject videoManager;
    // Start is called before the first frame update
    void Start()
    {
        videoManager = GameObject.Find("VideoPanel");
        gameMode = GameObject.Find("Camera");
    }

    // Update is called once per frame
    void Update()
    {
        //
        transform.Rotate(Vector3.up  * Time.deltaTime*speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        videoManager.GetComponent<MyVideoManager>().PlayVideo(1);
        videoManager.GetComponent<MyVideoManager>().i = 2;
        gameMode.GetComponent<MyPacManGameModeBase>().gameState = GameState.Pause;
        if (other.tag == "Player")
        {

            if (pos==true)
            {
                other.transform.localPosition= new Vector3(-3.02f, -0.02f, 0.14f);
            }
            else {
                other.transform.localPosition = new Vector3(0.02f, - 0.02f, 0.14f);   
            }
        }
    }
}
