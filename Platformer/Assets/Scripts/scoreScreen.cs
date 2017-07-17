using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreScreen : MonoBehaviour {
    private GameObject[] coinData;

    public GameObject[] platforms;
    public float platformMaxHeight = 2;
    public Camera scoreCam;

    // Use this for initialization
    void Start () {
        coinData = GameObject.FindGameObjectsWithTag("CoinData");
        Debug.Log("Length on coinData: " + coinData.GetLength(0).ToString());

        int totalCoins = 1;
        for(int n=0; n<=3;n++)
        {
            totalCoins += coinData[0].GetComponent<CoinData>().coins[n];
            Debug.Log(coinData[0].GetComponent<CoinData>().coins[n].ToString());

        }

        Debug.Log("Total Coins: " + totalCoins.ToString() );

        for ( int n = 0; n <= 3; n++ )
        {
            platforms[n].transform.position += new Vector3(0, platformMaxHeight * (coinData[0].GetComponent<CoinData>().coins[n] / (float)totalCoins), 0 );
        }
    }

    // Update is called once per frame
    void Update() {
        foreach(Camera cam in Camera.allCameras)
        {
            cam.enabled = false;
        }
        
        scoreCam.enabled = true;
	}
}
