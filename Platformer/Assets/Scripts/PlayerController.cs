using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    //public GameObject bulletPrefab;
    //public Transform bulletSpawn;
    public GameObject halo;
    public int maxJumps = 2;
    public int currentJumps = 0;
    public GameObject playerCam;
    public Vector3 respawn;
    public float respawnPoint = -20;
    public int coins = 0;
    private GameObject[] coinData;
    private Rigidbody rb;
    public Animator anim;

    //[SyncVar]
    //public static int currentPlayerNum = 0;

    [SyncVar]
    public int playerNum = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawn = transform.localPosition;
        coinData = GameObject.FindGameObjectsWithTag("CoinData");
        playerNum = GameObject.FindGameObjectsWithTag("Player").GetLength(0) - 1;
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (transform.position.y <= respawnPoint )
            transform.position = respawn;

        if (Input.GetKeyDown(KeyCode.Space) && currentJumps<maxJumps)
        {
            currentJumps++;

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.AddForce(0, 300, 0);
            anim.SetTrigger("Jump");
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        if( z > 0 )
        {
            anim.SetFloat("Running", 1);
            anim.SetBool("Idle", false);
        }
        else if( z < 0 )
        {
            anim.SetFloat("Running", -1);
            anim.SetBool("Idle", false);
        }
        else
        {
            anim.SetFloat("Running", 0);
            anim.SetBool("Idle", true);
        }

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

    public override void OnStartLocalPlayer()
    {
        halo.SetActive(true);
        playerCam.SetActive(true);
        playerCam.GetComponent<Camera>().enabled = true;
    }

    public void resetJumps()
    {
        currentJumps = 0;
    }

    public void collectCoin(int value )
    {
        coinData[0].GetComponent<CoinData>().coins[playerNum] += value;
    }
}