using Unity.Netcode;
using UnityEngine;

public class CustomPlayerSpawner : MonoBehaviour
{
    public GameObject hostPrefab;   // Player 1 (Stone)
    public GameObject clientPrefab; // Player 2 (Wind)

    private void Start()
    {
        NetworkManager.Singleton.OnServerStarted += OnServerStarted;
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
    }

    private void OnServerStarted()
    {
        if (NetworkManager.Singleton.IsHost)
        {
            SpawnPlayer(NetworkManager.Singleton.LocalClientId, hostPrefab);
        }
    }

    private void OnClientConnected(ulong clientId)
    {
        if (NetworkManager.Singleton.IsHost && clientId != NetworkManager.Singleton.LocalClientId)
        {
            // A new client has joined, spawn client prefab
            SpawnPlayer(clientId, clientPrefab);
        }
    }

    private void SpawnPlayer(ulong clientId, GameObject prefab)
    {
        GameObject playerInstance = Instantiate(prefab);
        playerInstance.GetComponent<NetworkObject>().SpawnAsPlayerObject(clientId);
    }
}
