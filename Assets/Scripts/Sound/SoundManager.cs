using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Windows;
using static SoundManager;

/*
 
soundManagerの作業方法
 空のGameObjectにSoundManagerスクリプトを入れる
入れるとbgm clips,Se clipsが見える
それぞれのリストに合う音源を入れる

鳴って欲しいSeをスクリプトに音がなるように書く
 
 */

public class SoundManager : SingletonMonoBehaviour<SoundManager>

{

    public enum BgmTable // 今持っているBGM
    {
        ActionBGM,
        EscapeBGM,
        TitleBGM_SE

    }

    public enum SeTable　// 今持っているSE
    {
        PlayerDamage,
        PlayerWalkSE_Stage1,
        TitleDecisionButtonSE,
        Jump
    }



    [SerializeField] private List<AudioClip> _bgmClips = new List<AudioClip>();
    [SerializeField] private List<AudioClip> _seClips = new List<AudioClip>();

    private List<AudioSource> _bgmAudioSources = new List<AudioSource>();
    private List<AudioSource> _seAudioSources = new List<AudioSource>();


    // 同時に再生可能数　동시 재생가능수
    private const int SeMax = 5;
    private const int BgmMax = 2;

    //public AudioSource BGM_title;
    //public AudioSource BGM_action;

    //private string beforeScene = "TitleScene"; //1つ前のシーンの名前

    // Start is called before the first frame update

    void Start()
    {
        foreach (var source in Enumerable.Range(0, BgmMax))
        {
            _bgmAudioSources.Add(gameObject.AddComponent<AudioSource>());
        }
        foreach (var source in Enumerable.Range(0, SeMax))
        {
            _seAudioSources.Add(gameObject.AddComponent<AudioSource>());
        }



    }




    public void PlayBgm(BgmTable bgmTable)　//   bgmがなる為のコード
    {
        _bgmAudioSources[0].clip = _bgmClips[(int)bgmTable];
        _bgmAudioSources[0].Play();
         
    }

    public void StopBgm()
    {
        _bgmAudioSources[0].Stop();
    }

    public void PlaySe(SeTable seTable, bool isLoop = false)    //   Seがなる為のコード
    {
        var seSource = _seAudioSources.FirstOrDefault(se => !se.isPlaying);
        if (seSource == null)
        {
            Debug.Log("Se に空きがありません");
            return;
        }
        seSource.clip = _seClips[(int)seTable];
        seSource.loop = isLoop;
        seSource.Play();
    }

    public void StopSe()
    {
        var seSources = _seAudioSources.Where(se => se.isPlaying).ToList();
        seSources.ForEach(se => se.Stop());
    }

    public bool IsPlaySe(SoundManager.SeTable seTable)
    {
        return _seAudioSources[(int)seTable].isPlaying;
    }





}
