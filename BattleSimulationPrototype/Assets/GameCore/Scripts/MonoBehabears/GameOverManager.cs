using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public TMPro.TMP_Text GameOverMassage;

    private void Start()
    {
        GameOverMassage.text = GameManager.Instance.GameOverMassage;
    }
    public void Restart()
    {
        GameManager.Instance.GameRestart();
    }
}
