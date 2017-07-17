using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    private float stepCount = 0;
    public GameObject triggeree;
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            stepCount++;
            if (stepCount == 1)
            {
                GetComponent<MeshRenderer>().material.color = Color.gray;
                triggeree.GetComponent<MovingPlatform>().Trigger();
                //if (triggeree.tag == "triggeree")
                //{
                //    triggeree.SendMessage("Trigger");
                //}
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
                GetComponent<MeshRenderer>().material.color = Color.yellow;
                triggeree.GetComponent<MovingPlatform>().Untrigger();
                //if ( triggeree.tag == "triggeree")
                //{
                //    triggeree.SendMessage("Untrigger");
                //}
            }
        }
    }

}

abstract public class Triggeree : MonoBehaviour
{
    public virtual void Trigger()
    {

    }
    public virtual void Untrigger()
    {

    }
}
