using UnityEngine;
using Unity.Netcode;

public class DoorController : NetworkBehaviour
{
    public enum SwitchAccess { Wind, Stone }
    public SwitchAccess accessType;
    public bool isOpen = false;
    public GameObject target;
        
    
    bool isCorrectPlayer()
    {
        if ((IsHost && accessType == SwitchAccess.Stone) || (IsClient && accessType == SwitchAccess.Wind)) return true;
        else return false;
    }

}


