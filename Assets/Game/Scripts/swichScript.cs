using UnityEngine;

public class PlayerSwitchActivator : MonoBehaviour
{
    public enum SwitchAccess { Wind, Stone }
    public SwitchAccess accessType = SwitchAccess.Stone;
    public GameObject doorToOpen;

    private bool isActivated = false;
    private Collider2D currentPlayerInZone;

    void Update()
    {
        if (currentPlayerInZone != null && IsCorrectPlayer(currentPlayerInZone))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ActivateSwitch();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (IsCorrectPlayer(other))
        {
            currentPlayerInZone = other;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (currentPlayerInZone == other)
        {
            currentPlayerInZone = null;
        }
    }

    bool IsCorrectPlayer(Collider2D other)
    {
        if (other.CompareTag("stoneGolem")) return true;
        return false;
    }

    void ActivateSwitch()
    {
        if (!isActivated)
        {
            isActivated = true;

            // Insert your switch logic here (e.g. open door)
            OpenDoor();
        }
    }
    void OpenDoor()
    {
        if (doorToOpen != null)
        {
            // 1. Get the DoorController component
            DoorController doorScript = doorToOpen.GetComponent<DoorController>();

            if (doorScript != null)
            {
                // 2. Change the variable
                doorScript.isOpen = true;
                print(doorScript.isOpen);
            }
        }
    }
}
