using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EndOfLevel : MonoBehaviour {
    public int reqPlayers = 4;
    public int currentPlayers = 0;
    public GameObject[] networkManager;
    public string Scene = "";

    // Use this for initialization
    void Start () {
        networkManager = GameObject.FindGameObjectsWithTag("NetworkManager");
	}
	
	// Update is called once per frame
	void Update () {
		if( currentPlayers >= reqPlayers )
        {
            Debug.Log("Level clear");
            networkManager[0].GetComponent<NetworkManager>().ServerChangeScene(Scene);
        }
	}
}
