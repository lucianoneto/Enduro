using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartButton : MonoBehaviour
{
    public float countdownTime = 0f; // tempo da contagem regressiva em segundos

    public void OnClick()
    {   
        StartGame();
        //Invoke("StartGame", countdownTime);
    }

    void StartGame()
    {       
        SceneManager.LoadScene("GameScene");
    }
}
