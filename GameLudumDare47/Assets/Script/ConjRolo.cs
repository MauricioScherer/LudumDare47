using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConjRolo : MonoBehaviour
{
    private Transform target;

    public int startTarget;
    public float speed;
    public Transform rolo;
    public Transform[] posTarget;

    // Start is called before the first frame update
    void Start()
    {
        target = posTarget[startTarget];
    }

    // Update is called once per frame
    void Update()
    {
        rolo.transform.position = Vector3.MoveTowards(rolo.transform.position, target.position, speed * Time.deltaTime);

        if(rolo.transform.position == target.position)
        {
            if (startTarget == 0)
                startTarget = 1;
            else
                startTarget = 0;

            target = posTarget[startTarget];
        }
    }
}
