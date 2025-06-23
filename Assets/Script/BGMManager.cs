using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMManager : MonoBehaviour
{
    private AudioSource _audiosource;

    public Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        _audiosource = GetComponent<AudioSource>();
        _audiosource.Play();        //AudioSourceでBGMを再生する

        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
            _audiosource.volume = volumeSlider.value; // 初期値を反映
        }
    }

    private void StopBGM()
    {
        _audiosource.Stop();
    }
    
    public void ChangeBGM(AudioClip newClip)
    {
        _audiosource.clip = newClip;
        _audiosource.Play();
    }

    public void ChangeVolume(float value)
    {
        _audiosource.volume = value; // スライダーの値で音量を調整
    }
}
