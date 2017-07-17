using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestination : MonoBehaviour {
    public MovingPlatform mp;

	void OnTriggerEnter()
    {
        mp.returning = true;
    }
}
