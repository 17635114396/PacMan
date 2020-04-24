using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyButtonManager : MonoBehaviour
{
    GameObject camrea;
    GameObject canvas;
    GameObject player;

    /// <summary>
    /// 开始里的按钮
    /// </summary>
    Button starting;
    Button setting;
    Button exiting;

    /// <summary>
    /// 设置里的按钮
    /// </summary>
    //GameObject scoreText;
    Button returnMenue;
    Slider audioSld;
    public int materialIndex = 0;
    Toggle[] toogleButtons;
    Button aboutUs;

    /// <summary>
    /// 失败/胜利按钮
    /// </summary>
    Button failedRestart;
    Button victoryRestart;

    // Start is called before the first frame update
    void Start()
    {
        camrea = GameObject.Find("Camera");
        canvas = GameObject.Find("Canvas");
        player = GameObject.FindGameObjectWithTag("Player");

        starting= GameObject.Find("Starting").GetComponent<Button>();
        starting.onClick.AddListener(StartPlying);

        setting = GameObject.Find("Seting").GetComponent<Button>();
        setting.onClick.AddListener(ShowSet);

        exiting = GameObject.Find("Exiting").GetComponent<Button>();
        exiting.onClick.AddListener(ExitGame);

        canvas.GetComponent<MyScoreManager>().ScoreText.transform.localPosition = new Vector3(10000, 0, 0);
        returnMenue = GameObject.Find("ReturnMenu").GetComponent<Button>();
        returnMenue.onClick.AddListener(ReturnMenu);

        audioSld = GameObject.Find("AudioSlider").GetComponent<Slider>();
        audioSld.onValueChanged.AddListener(AudioChange);

        toogleButtons = GetComponentsInChildren<Toggle>();
        for (int i = 0; i < toogleButtons.Length; i++)
        {
            int K = i;//这一步是必须记录的，用来区分那个toggle
            toogleButtons[K].onValueChanged.AddListener((bool value) => SetEveryToggle(value, K));
        }

        aboutUs = GameObject.Find("AboutUs").GetComponent<Button>();
        aboutUs.onClick.AddListener(OpenAboutUs);

        failedRestart= GameObject.Find("FailedReStart").GetComponent<Button>();
        failedRestart.onClick.AddListener(MyRestart);

        victoryRestart = GameObject.Find("VictoryReStart").GetComponent<Button>();
        victoryRestart.onClick.AddListener(MyRestart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// 菜单->开始游戏
    /// </summary>
    void StartPlying()
    {
        camrea.GetComponent<MyPacManGameModeBase>().gameState = GameState.Playing;
        camrea.GetComponent<MyAudioManager>().PlayAudio(5);
        camrea.GetComponent<MyAudioManager>().PlayLongAudio(0);
    }

    /// <summary>
    /// 菜单->更改模式为设置
    /// </summary>
    void ShowSet()
    {
        camrea.GetComponent<MyAudioManager>().PlayAudio(5);
        camrea.GetComponent<MyPacManGameModeBase>().gameState = GameState.Set;
    }

    /// <summary>
    /// 菜单->退出游戏
    /// </summary>
    void ExitGame()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MyAudioManager>().PlayAudio(5);
        //UnityEditor.EditorApplication.isPlaying = false;//打包前的退出
        Application.Quit();//打包后的退出
    }



    /// <summary>
    ///  设置->更改游戏模式为菜单
    /// </summary>
    void ReturnMenu()
    {
        canvas.GetComponent<MyScoreManager>().ScoreText.transform.localPosition = new Vector3(10000, 0, 0);
        camrea.GetComponent<MyAudioManager>().PlayAudio(9);
        camrea.GetComponent<MyPacManGameModeBase>().gameState = GameState.Menu;
    }

    /// <summary>
    /// 设置->按钮->改变音量
    /// </summary>
    void AudioChange(float volum)
    {
       camrea.GetComponent<MyAudioManager>().volumChange = volum;
       camrea.GetComponent<MyAudioManager>().PlayAudio(4);
    }

    /// <summary>
    /// 设置->更改背景贴图
    /// </summary>
    /// <param name="value">是否勾选</param>
    /// <param name="j">第几个选框</param>
    void SetEveryToggle(bool value, int j)
    {
        if (j == 0 && value)
        {
            Ston();
        }
        if (j == 1 && value)
        {
            Ocean();
        }
        if (j == 2 && value)
        {
            Desirt();
        }
        if (j == 3 && value)
        {
            Grass();
        }
    }

    /// <summary>
    /// 设置->根据不同的选项更换索引号
    /// </summary>
    void Ocean()
    {
        materialIndex = 4;
    }
    void Grass()
    {
        materialIndex = 1;
    }
    void Desirt()
    {
        materialIndex = 3;
    }
    void Ston()
    {
        materialIndex = 2;
    }

    /// <summary>
    /// 设置->按钮->打开网页
    /// </summary>
    void OpenAboutUs() {
        camrea.GetComponent<MyAudioManager>().PlayAudio(9);
        Application.OpenURL("https://github.com/17635114396/PacMan/");
    }



    /// <summary>
    /// 失败或胜利->初始化场景信息
    /// </summary>
    void MyRestart()
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
        camrea.GetComponent<MyAudioManager>().PlayLongAudio(3);
        //初始化火焰特效
        GameObject.FindGameObjectWithTag("fire").transform.localPosition = new Vector3(0, 5f, 0);
        //初始化分数
        canvas.GetComponent<MyScoreManager>().getPoint = 0;
        //初始化无敌状态
        player.GetComponent<MyPacManMove>().isBaTi = false;
        //初始化分数位置
        canvas.GetComponent<MyScoreManager>().ScoreText.transform.localPosition = new Vector3(10000, 0, 0);
    }

    /// <summary>
    /// 失败或胜利->子函数->清空场景中的敌人
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
