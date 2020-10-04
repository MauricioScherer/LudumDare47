using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoColor : MonoBehaviour
{
    private MeshRenderer mesh;
    public int initialValue;

    public Material[] materials;
    public bool correct;
    public int materialCorrect;

    private void Start()
    {
        StartRand();
    }

    public void StartRand()
    {
        mesh = GetComponent<MeshRenderer>();

        if(!correct)
        {
            initialValue = Random.Range(0, 4);
            mesh.material = materials[initialValue];
        }
        else
        {
            mesh.material = materials[materialCorrect];
        }
    }
}
