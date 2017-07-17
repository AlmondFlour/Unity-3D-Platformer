using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour {
    public PlayerController player;

	void OnTriggerEnter(Collider col)
    {
        player.resetJumps();
    }
}
