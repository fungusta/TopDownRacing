using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void onClickStartHost()
    {
        NetworkManager.Singleton.StartHost();
    }

    public void onClickStartServer()
    {
        NetworkManager.Singleton.StartServer();
    }

    public void onClickStartClient()
    {
        NetworkManager.Singleton.StartClient();
    }
}
