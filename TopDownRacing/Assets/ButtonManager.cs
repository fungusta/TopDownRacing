using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void OnClickStartHost()
    {
        NetworkManager.Singleton.StartHost();
        DeactiveUI();
    }

    public void OnClickStartServer()
    {
        NetworkManager.Singleton.StartServer();
        DeactiveUI();
    }

    public void OnClickStartClient()
    {
        NetworkManager.Singleton.StartClient();
        DeactiveUI();
    }

    private void DeactiveUI()
    {
        this.gameObject.SetActive(false);
    }
}
