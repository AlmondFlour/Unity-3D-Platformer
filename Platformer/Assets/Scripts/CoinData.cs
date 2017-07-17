using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinData : MonoBehaviour {
    public int[] coins;

	// Use this for initialization
	void Start () {
        coins = new int[4] { 0, 0, 0, 0 };
	}

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
