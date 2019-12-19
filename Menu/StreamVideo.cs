using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StreamVideo : MonoBehaviour
{
    public RawImage rawimage;
    public VideoPlayer videoplayer;
    public AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Playvideo());
    }
    IEnumerator Playvideo()
    {
        videoplayer.Prepare();
        WaitForSeconds WaitForSeconds = new WaitForSeconds(1);
        while(!videoplayer.isPrepared)
        {
            yield return WaitForSeconds;
            break;
        }
        rawimage.texture = videoplayer.texture;
        videoplayer.Play();
        audiosource.Play();
    }
}
