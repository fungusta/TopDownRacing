using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsManager : MonoBehaviour
{
    public CheckPointsInteractions[] checkPointsManagers;
    // Start is called before the first frame update
    void Start()
    {
        checkPointsManagers = GetComponentsInChildren<CheckPointsInteractions>();
        for (int i = 0; i < checkPointsManagers.Length; i++)
        {
            checkPointsManagers[i].index = i + 1;
        }
        checkPointsManagers[checkPointsManagers.Length - 1].isEnd = true;
    }
}
