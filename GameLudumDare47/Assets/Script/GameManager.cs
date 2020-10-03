using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public AudioClip[] clip;
    public AudioSource soundEffect;

    public GameObject player;
    public Transform respawnPosition;

    private void Awake()
    {
        Instance = this;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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

        player.GetComponent<Transform>().position = respawnPosition.position;
        player.GetComponent<Transform>().rotation = respawnPosition.rotation;
        Invoke("ResetMovePLayer", 0.2f);
    }

    private void ResetMovePLayer()
    {
        player.GetComponent<Player>().SetIsMove();
    }
}
