using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public bool moving = false;
    public bool returning = false;
    public Transform destination;
    public Vector3 start;
    public Vector3 currentDestination;
    public float speed = 4;

	// Use this for initialization
	void Start () {
        start = transform.position;
        currentDestination = destination.position;
	}
	
	// Update is called once per frame
	void Update () {
		if( moving  )
        {
            transform.position = Vector3.MoveTowards(transform.position, currentDestination, speed * Time.deltaTime);

            Vector3 dest = currentDestination;
            Vector3 pos = transform.position;

            if ( Mathf.Max( Mathf.Abs(pos.x - dest.x), Mathf.Abs(pos.y - dest.y) , Mathf.Abs(pos.z - dest.z) ) <= 0.05 )
            {
                returning = !returning;
                if (returning)
                    currentDestination = start;
                else
                    currentDestination = destination.position;
            }
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if( col.tag == "Player" )
        {
            col.transform.parent = transform;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            col.transform.parent = null;
        }
    }

    public void Trigger()
    {
        moving = !moving;
    }

    public void Untrigger()
    {
        moving = false;
    }
}
