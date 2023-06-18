using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;

public class ResourcesDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text resourceText = null;

    private RTSPlayer player;

    private void Update() 
    {
        if (player == null)
        {
            player = NetworkClient.connection.identity.GetComponent<RTSPlayer>();

            if (player != null)
            {
                ClientHandleResourceUpdated(player.GetResources());

                player.ClientOnResourcesUpdated += ClientHandleResourceUpdated;
            }
        }    
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
