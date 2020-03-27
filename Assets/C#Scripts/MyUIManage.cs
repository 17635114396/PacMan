using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyUIManage : MonoBehaviour
{
    GameObject gameMode;//传递游戏模式
    public GameObject[] GameUI;//传递UI界面

    Vector3 show = new Vector3(0, 0, 0);//显示UI
    Vector3 noShow = new Vector3(-1800f, 0, 0);//不显示UI

    Slider sl;//音量条
    public float volum = 1;//音量参数

    private void Awake()
    {
        MyAwakeRestart();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameMode = GameObject.Find("Camera");
        GameUI[4].transform.localPosition = noShow;
        sl = GameObject.Find("AudioSlider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        ShowUI();
    }

    /// <summary>
    /// 模式管理->子函数->UI隐藏
    /// </summary>
    void NullState()
    {
        for (int i = 0; i < GameUI.Length; i++)
        {
            GameUI[i].transform.localPosition = noShow;
        }
    }

    /// <summary>
    /// 模式管理->根据游戏状态实现相关UI的显示
    /// </summary>
    void ShowUI()
    {
        if (gameMode.GetComponent<MyPacManGameModeBase>().gameState == GameState.Playing)
        {
            Time.timeScale = 1;
            NullState();
        }
        else if (gameMode.GetComponent<MyPacManGameModeBase>().gameState == GameState.Set)
        {
            Time.timeScale = 0.001f;
            for (int i = 0; i < GameUI.Length; i++)
            {
                if (i == 4)
                {
                    GameUI[i].transform.localPosition = show;
                }
                else
                {
                    GameUI[i].transform.localPosition = noShow;
                }
            }
        }
        else if (gameMode.GetComponent<MyPacManGameModeBase>().gameState == GameState.Menu)
        {
            Time.timeScale = 0.001f;
            for (int i = 0; i < GameUI.Length; i++)
            {
                if (i == 0)
                {
                    GameUI[i].transform.localPosition = show;
                }
                else
                {
                    GameUI[i].transform.localPosition = noShow;
                }
            }
        }
        else if (gameMode.GetComponent<MyPacManGameModeBase>().gameState == GameState.Pause)
        {
            Time.timeScale = 0.001f;
            for (int i = 0; i < GameUI.Length; i++)
            {
                if (i == 1)
                {
                    GameUI[i].transform.localPosition = show;
                }
                else
                {
                    GameUI[i].transform.localPosition = noShow;
                }
            }
        }
        else if (gameMode.GetComponent<MyPacManGameModeBase>().gameState == GameState.Win)
        {
            for (int i = 0; i < GameUI.Length; i++)
            {
                if (i == 2)
                {
                    GameUI[i].transform.localPosition = show;
                }
                else
                {
                    GameUI[i].transform.localPosition = noShow;
                }
            }
        }
        else if (gameMode.GetComponent<MyPacManGameModeBase>().gameState == GameState.GameOver)
        {
            gameMode.GetComponent<MyAudioManager>().PlayAudio(2);
            Time.timeScale = 0.001f;
            for (int i = 0; i < GameUI.Length; i++)
            {
                if (i == 3)
                {
                    GameUI[i].transform.localPosition = show;
                }
                else
                {
                    GameUI[i].transform.localPosition = noShow;
                }
            }
        }
    }

    /// <summary>
    /// 菜单->更改模式为设置
    /// </summary>
    public void ShowSet()
    {
        gameMode.GetComponent<MyAudioManager>().PlayAudio(5);
        gameMode.GetComponent<MyPacManGameModeBase>().gameState = GameState.Set;
    }

    /// <summary>
    ///  设置->更改游戏模式为菜单
    /// </summary>
    public void ReturnMenu()
    {
        gameMode.GetComponent<MyAudioManager>().PlayAudio(9);
        gameMode.GetComponent<MyPacManGameModeBase>().gameState = GameState.Menu;
    }

    /// <summary>
    /// 设置->改变音量
    /// </summary>
    public void AudioChange()
    {
        volum = sl.value;
        gameMode.GetComponent<MyAudioManager>().PlayAudio(4);
    }

    /// <summary>
    /// 失败->初始化场景信息
    /// </summary>
    public void MyRestart()
    {
        //设置游戏模式为菜单模式
        ReturnMenu();
        //清空敌人
        ClearEnemy();
        //清空技能物体
        var MagicThing = GameObject.FindGameObjectWithTag("TuDun");
        Destroy(MagicThing);
        //初始化敌人
        GameObject.Instantiate(Resources.Load("Prefabs/enemy"));
        //初始化主角位置
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0f, 0f, -4.5f);
        //初始化豆子
        GameObject.Instantiate(Resources.Load("Prefabs/Foods"));
        GameObject.Instantiate(Resources.Load("Prefabs/GoodFood"));
        //初始化音乐
        gameMode.GetComponent<MyAudioManager>().PlayLongAudio(3);
        //初始化火焰特效
        GameObject.FindGameObjectWithTag("fire").transform.localPosition = new Vector3(0, 5f, 0);
    }

    /// <summary>
    /// 唤醒->场景基本信息【供Awake调用】
    /// </summary>
    public void MyAwakeRestart()
    {
        //清空敌人
        ClearEnemy();
        //初始化敌人
        GameObject.Instantiate(Resources.Load("Prefabs/enemy"));
        //初始化主角位置
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0f, 0f, -4.5f);
        //初始化豆子
        GameObject.Instantiate(Resources.Load("Prefabs/Foods"));
        GameObject.Instantiate(Resources.Load("Prefabs/GoodFood"));
        GameObject.FindGameObjectWithTag("fire").transform.localPosition = new Vector3(0, 5f, 0);
    }

    /// <summary>
    /// 失败->子函数->清空场景中的敌人
    /// </summary>
    void ClearEnemy()
    {
        //清空场景中的敌人
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
    }
}
