using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsInteractions : MonoBehaviour
{
    public int index;
    public bool isEnd;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<PlayerLapManager>()) //guard clause 1
        {
            return;
        }
        PlayerLapManager player = other.gameObject.GetComponent<PlayerLapManager>();
        if (!player.IsSameCheckpoint(index - 1)) //guard clause 2
        {
            return;
        }

        player.UpdateCheckpointIndex(index);
        Debug.Log("Past a checkpoint");
        if (!isEnd) //guard clause 3
        {
            return;
        }
        player.NewLap();
        Debug.Log("Current Lap: " + player.lapNumber);

    }
}
