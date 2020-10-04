using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadLevel(int p_value)
    {
        SceneManager.LoadScene(p_value);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
