﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public AudioClip[] clip;
    public AudioSource soundEffect;

    public GameObject player;
    public GameObject respawnPosition;

    public GameObject[] fechamento;

    public GameObject pause;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!pause.activeSelf)
            {
                pause.SetActive(true);
                Time.timeScale = 0.0f;
            }
            else
            {
                pause.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }
    }

    public void ReturnPause()
    {
        pause.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void PlaySoundEffect(int p_clip)
    {
        //p_clip == 0 (loopLevel)
        soundEffect.clip = clip[p_clip];
        soundEffect.Play();
    }

    public void ResetPlayer()
    {
        soundEffect.clip = clip[0];
        soundEffect.Play();

        //reset door status
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
        foreach (GameObject thisDoor in doors)
        {
            if(thisDoor.GetComponent<Door>())
                thisDoor.GetComponent<Door>().Open(false);
        }

        //fechamentos
        foreach (GameObject fechamentoCurrent in fechamento)
            fechamentoCurrent.SetActive(false);
        fechamento[0].SetActive(true);

        player.GetComponent<Player>().SetIsMove();
        player.GetComponent<Transform>().position = respawnPosition.GetComponent<Transform>().position;
        player.GetComponent<Transform>().rotation = respawnPosition.GetComponent<Transform>().rotation;
        Invoke("ResetMovePLayer", 0.2f);
    }

    private void ResetMovePLayer()
    {
        player.GetComponent<Player>().SetIsMove();
    }

    public void ViewFechamento(int p_sala)
    {
        fechamento[p_sala - 1].SetActive(false);
        fechamento[p_sala].SetActive(true);
    }

    public void LoadLevel(int p_value)
    {
        SceneManager.LoadScene(p_value);
    }
}
