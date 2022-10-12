using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLapManager : MonoBehaviour
{
    public int lapNumber;
    public int checkpointIndex;

    // Start is called before the first frame update
    private void Awake()
    {
        lapNumber = 1;
        checkpointIndex = 0;
    }
}
