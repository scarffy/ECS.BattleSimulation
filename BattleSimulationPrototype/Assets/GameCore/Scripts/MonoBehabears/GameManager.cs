using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    WAITING,
    READY,
    PLAYING,
    GAMEOVER
}


public enum SpawnState
{
    PLAYER,
    ENEMY,
    COMPLETE
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UnitData SelectedData;

    [SerializeField]
    private GameState gamePlayState;

    public SceneManagerSO SceneManagerSO;

    public GameState GamePlayState { get => gamePlayState;private set => gamePlayState = value; }

    public string GameOverMassage;

    public SpawnState Ready;

    private void Awake()
    {
        Instance = this;
    }

    public void GameReady()
    {
        if(GamePlayState == GameState.WAITING)
        {
            GamePlayState = GameState.READY;
        }
    }
    public void GameStart()
    {
        if(GamePlayState == GameState.READY)
        {
            GamePlayState = GameState.PLAYING;
            SceneManagerSO.UnLoadAllSceneAsync();
            SceneManagerSO.LoadSceneAdditive("GamePanel");
        }
    }

    public void GameOver()
    {
        if (GamePlayState == GameState.PLAYING)
        {
            GamePlayState = GameState.GAMEOVER;
            SceneManagerSO.UnLoadAllSceneAsync();
            SceneManagerSO.LoadSceneAdditive("GameOverPanel");
        }
    }

    public void GameRestart()
    {
        if (GamePlayState == GameState.GAMEOVER)
        {
            GamePlayState = GameState.WAITING;
            SceneManagerSO.UnLoadAllSceneAsync();
            SceneManagerSO.LoadSceneAdditive("GameStartPanel");
        }
    }

    public void PlayerReady()
    {
        Ready = SpawnState.ENEMY;
    }

}
