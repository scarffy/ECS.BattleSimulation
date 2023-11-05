using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;
    [SerializeField] private SceneManagerSO sceneManager_SO;

    public SceneTransition sceneTransition;

    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            /*QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 15;*/
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void LoadScene(string scenename)
    {
        if(sceneTransition!=null)
        {
            sceneTransition.OnTransitionComplete = () => { LoadSceneAsync(scenename); };
            sceneTransition.StartTransition();
        }
        else
        {
            LoadSceneAsync(scenename);
        }
        
    }

    public void LoadSceneAdditive(string scenename)
    {
        sceneManager_SO.LoadSceneAdditive(scenename);
    }

    public void LoadSceneAsync(string scenename, bool additive = false, Action oncomplete = null)
    {
        sceneManager_SO.LoadSceneAsync(scenename, additive,oncomplete);
    }

    public void UnLoadSceneAsync(string scenename)
    {
        sceneManager_SO.UnLoadSceneAsync(scenename);
        
    }

    public void UnLoadAllSceneAsync()
    {
        sceneManager_SO.UnLoadAllSceneAsync();
    }
}
