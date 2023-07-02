using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;

public class ResourcesDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text resourceText = null;

    private RTSPlayer player;

    private void Start() 
    {
        player = NetworkClient.connection.identity.GetComponent<RTSPlayer>();

        ClientHandleResourceUpdated(player.GetResources());

        player.ClientOnResourcesUpdated += ClientHandleResourceUpdated;
    }

    private void OnDestroy() 
    {
        player.ClientOnResourcesUpdated -= ClientHandleResourceUpdated;
    }
    
    private void ClientHandleResourceUpdated(int resources)
    {
        resourceText.text = $"Resources: {resources}";
    }
}
