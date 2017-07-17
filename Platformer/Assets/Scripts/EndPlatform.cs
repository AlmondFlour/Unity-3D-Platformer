using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlatform : MonoBehaviour {
    private int stepCount = 0;
    public EndOfLevel eol;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            stepCount++;
            if (stepCount == 1)
            {
                GetComponent<MeshRenderer>().material.color = Color.blue;
                eol.currentPlayers++;
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            stepCount--;
            if (stepCount == 0)
            {
                GetComponent<MeshRenderer>().material.color = Color.red;
                eol.currentPlayers--;
            }
        }
    }
}
