using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class StartAnim : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    void Start()
    {
        if(videoPlayer == null)
        {
            Debug.LogError("���� �÷��̾ �Ҵ���� ����");
            return;
        }
        videoPlayer.loopPointReached += OnVideoEnded;
        videoPlayer.Play();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
    }

    private void OnVideoEnded(VideoPlayer vp)
    {
        SceneManager.LoadScene(1);
    }
}
