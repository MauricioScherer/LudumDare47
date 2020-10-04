using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalMenu : MonoBehaviour
{
    public GameObject gameBy;
    public GameObject btnExit;

    private void Start()
    {
        Invoke("GameByFinal", 10.0f);
        Invoke("btnExitFinal", 12.0f);
    }

    private void GameByFinal()
    {
        gameBy.SetActive(true);
    }

    private void btnExitFinal()
    {
        btnExit.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
