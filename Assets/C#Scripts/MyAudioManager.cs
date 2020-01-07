using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAudioManager : MonoBehaviour
{
    GameObject uiManage;//传递音量条
    float beginVol = 1f;//起始音量

    public AudioSource audioSource1;
    public AudioSource audioSource2;

    public AudioClip[] allLittleAudio;//所有短音频
    public int littleNumberAudio;//短音频索引

    public AudioClip[] allLongAudio;//所有长音频
    public int longNumberAudio;//长音频索引

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        var aS = this.gameObject.GetComponents(typeof(AudioSource));
        audioSource1 = (AudioSource)aS[0];
        audioSource2 = (AudioSource)aS[1];
        PlayLongAudio(3);

        uiManage = GameObject.Find("Canvas");

        audioSource1.volume = beginVol;
        audioSource2.volume = beginVol;

        player= GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //更新音量
        audioSource1.volume = uiManage.GetComponent<MyUIManage>().volum*0.5f;
        audioSource2.volume = uiManage.GetComponent<MyUIManage>().volum;
        ChangeAudioAsPac();
    }

    /// <summary>
    /// 播放短音频
    /// </summary>
    /// <param name="i"></param>
    public void PlayAudio(int i)
    {

        audioSource1.clip = allLittleAudio[i];
        audioSource1.Play();
    }

    /// <summary>
    /// 播放长音频
    /// </summary>
    /// <param name="i"></param>
    public void PlayLongAudio(int i)
    {
        audioSource2.clip = allLongAudio[i];
        audioSource2.Play();
    }

    /// <summary>
    /// 检测无敌状态消失要做的事
    /// </summary>
    public void ChangeAudioAsPac()
    {
        bool c = audioSource2.isPlaying;
        if (c== false)
        {
            PlayLongAudio(10);
            GameObject.FindGameObjectWithTag("fire").transform.localPosition = new Vector3(0, 5f, 0);
            player.GetComponent<MyPacManMove>().isBaTi = false;
            audioSource2.loop = true;
        }
    }
}
