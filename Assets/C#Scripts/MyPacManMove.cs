using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPacManMove : MonoBehaviour
{
    GameObject gameMode;//传递游戏模式
    GameObject[] enemies;//传递敌人


    public float speed = 1;//位移速度
    Vector3 diff;//位移偏差值

    public int i = 0;//相机编号

    public bool isBaTi;//是否为霸体状态

    Transform EnemyRebornPos;//敌人重生老巢位置

    GameObject videoManager;
    GameObject scoreText;

    // Start is called before the first frame update
    private void Start()
    {
        videoManager = GameObject.Find("VideoPanel");
        gameMode = GameObject.Find("Camera");
        EnemyRebornPos = GameObject.FindGameObjectWithTag("EnemyRebornPos").transform;
        scoreText = GameObject.Find("Canvas");

    }

    // fixedUpdate is called once per frame
    private void FixedUpdate()
    {
        GetDiff();
        Move();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    /// <summary>
    /// 根据偏差方向实现位移
    /// </summary>
    void Move()
    {
        //游戏进行中时玩家可以移动
        if (gameMode.GetComponent<MyPacManGameModeBase>().gameState == GameState.Playing)
        {
            transform.LookAt(this.transform.position + diff);//可以向斜上方看
            this.transform.position += diff * speed;
        }
    }

    /// <summary>
    /// 根据按钮获取偏差方向，并改变相应相机参数
    /// </summary>
    void GetDiff()
    {
        if (Input.GetKey(KeyCode.A))
        {
            diff = new Vector3(-1, 0, 0);//i = 0;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            diff = new Vector3(0, 0, -1); //i = 3;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            diff = new Vector3(1, 0, 0);//i = 2;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            diff = new Vector3(0, 0, 1);//i = 1;
        }
        else
            diff = Vector3.zero;
    }

    /// <summary>
    /// 检测豆子的碰撞，销毁豆子，播放特效和声音
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        GameObject[] collections = GameObject.FindGameObjectsWithTag("Collections");
        //碰到普通豆子
        if (other.tag == "Collections")
        {
            scoreText.GetComponent<MyScoreManager>().getPoint += scoreText.GetComponent<MyScoreManager>().commonGetPoint;
            //胜利条件:最后一个
            if (collections.Length == 1)
            {
                //设置游戏状态为胜利
                gameMode.GetComponent<MyPacManGameModeBase>().gameState = GameState.Win;
                //播放声音
                //gameMode.GetComponent<MyAudioManager>().PlayAudio(3);
                gameMode.GetComponent<MyAudioManager>().PlayLongAudio(5);
                Destroy(other.gameObject);
            }
            //还未胜利
            else
            {
                //危局条件
                if (collections.Length == 10)
                {
                    //改变地图颜色，灯光，后续做
                    gameMode.GetComponent<MyAudioManager>().PlayLongAudio(11);
                }
                gameMode.GetComponent<MyAudioManager>().PlayAudio(0);
                Destroy(other.gameObject);
            }
        }
        //碰到敌人
        else if (other.tag == "Enemy")
        {
            //无敌状态
            if (isBaTi == true)
            {
                gameMode.GetComponent<MyAudioManager>().PlayAudio(7);
                other.gameObject.GetComponent<MeshRenderer>().enabled = false;
                other.gameObject.GetComponent<MyEnemy>().nav.SetDestination(EnemyRebornPos.position);
                other.gameObject.GetComponent<MyEnemy>().nav.speed = 0.7f;
            }
            //不是无敌状态，但敌人是幽灵状态
            else if (other.GetComponent<MeshRenderer>().enabled == false)
            {

            }
            //不是无敌状态，碰到敌人游戏失败
            else
            {
                gameMode.GetComponent<MyPacManGameModeBase>().gameState = GameState.GameOver;
                //gameMode.GetComponent<MyAudioManager>().PlayAudio(8);
                gameMode.GetComponent<MyAudioManager>().PlayLongAudio(12);
            }
        }
        //吃到灵豆，设置主角为无敌状态及
        else if (other.tag == "GoodFood")
        {
            scoreText.GetComponent<MyScoreManager>().getPoint += scoreText.GetComponent<MyScoreManager>().superGetpoint;

            videoManager.GetComponent<MyVideoManager>().PlayVideo(2);
            videoManager.GetComponent<MyVideoManager>().i = 3;
            gameMode.GetComponent<MyPacManGameModeBase>().gameState = GameState.Pause;

            isBaTi = true;
            GameObject.FindGameObjectWithTag("fire").transform.localPosition = new Vector3(0, 0, 0);
            gameMode.GetComponent<MyAudioManager>().PlayLongAudio(7);
            gameMode.GetComponent<MyAudioManager>().audioSource2.loop = false;

            Destroy(other.gameObject);


        }
        //碰到墙，待完善
        //else if (other.tag == "CrashWall")
        //{
        //    gameMode.GetComponent<MyAudioManager>().PlayAudio(6);
        //}
    }
}
