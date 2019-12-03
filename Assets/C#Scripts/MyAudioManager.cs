using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAudioManager : MonoBehaviour
{
    GameObject uiManage;//传递音量条
    float beginVol = 1f;//起始音量

    AudioSource audioSource1;
    AudioSource audioSource2;

    public AudioClip[] allLittleAudio;//所有短音频
    public int littleNumberAudio;//短音频索引

    public AudioClip[] allLongAudio;//所有长音频
    public int longNumberAudio;//长音频索引


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
    }

    // Update is called once per frame
    void Update()
    {
        //更新音量
        audioSource1.volume = uiManage.GetComponent<MyUIManage>().volum;
        audioSource2.volume = uiManage.GetComponent<MyUIManage>().volum;
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
}
