using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public bool btnCorrect;

    public GameObject door;
    public int numeroSala;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(Input.GetKeyDown("e"))
            {
                if(!btnCorrect)
                {
                    GameManager.Instance.ResetPlayer();
                    door.GetComponent<Door>().Open(false);
                }
                else
                {
                    door.GetComponent<Door>().Open(true);
                    GameManager.Instance.ViewFechamento(numeroSala);
                }
            }
        }
    }
}
