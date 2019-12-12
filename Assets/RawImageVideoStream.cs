using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RawImageVideoStream : MonoBehaviour
{

    public VideoPlayer videoReference;
    public AudioSource audioReference;
    public RawImage rawImageAsset1;
    public RawImage rawImageAsset2;
    public RawImage rawImageAsset3;

    public float delay = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
         
    }


    public void startPlayingVideoRefence()
    {
        StartCoroutine(playVideo());    
    
    }

    IEnumerator playVideo()
    {
        videoReference.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(delay);
        while (!videoReference.isPrepared) 
        {
            yield return waitForSeconds;
        }

        rawImageAsset1.texture = videoReference.texture;
        rawImageAsset2.texture = videoReference.texture;
        rawImageAsset3.texture = videoReference.texture;
        videoReference.Play();
        audioReference.Play();
    
    }
 
}
