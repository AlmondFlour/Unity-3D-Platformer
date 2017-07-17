using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    public int value = 1;

	void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<PlayerController>().collectCoin(value);
            Destroy(this.gameObject);
        }
    }
}
