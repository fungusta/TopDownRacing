using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;

public class PlayerLapManager : NetworkBehaviour
{
    public int lapNumber;
    public int checkpointIndex;
    public TMP_Text textMeshPro;

    static readonly string LAP_TEXT = "Lap: ";

    private void Awake()
    {
        lapNumber = 1;
        checkpointIndex = 0;
    }

    private void Update()
    {
        if (!IsLocalPlayer)
        {
            return;
        }
        textMeshPro.text = LAP_TEXT + lapNumber;
    }


    public bool IsSameCheckpoint(int index)
    {
        return checkpointIndex == index;
    }

    public void UpdateCheckpointIndex(int newIndex)
    {
        checkpointIndex = newIndex;
    }

    public void NewLap()
    {
        lapNumber++;
        checkpointIndex = 0;
    }
}
