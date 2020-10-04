using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject objFog;

    public void Open(bool p_status)
    {
        GetComponent<Animator>().SetBool("Open", p_status);
        objFog.SetActive(p_status);
    }
}
