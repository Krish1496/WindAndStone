using UnityEngine;

public class pressurePlateScript : MonoBehaviour
{

    private bool isActivated = false;
    private Collider2D currentPlayerInZone;

    void Update()
    {
        print(isActivated);
        if (currentPlayerInZone != null && IsCorrectPlayer(currentPlayerInZone))
        {
            ActivateSwitch();
        }
        else
        {
            DeactivateSwitch();
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
        }
    }
    void DeactivateSwitch()
    {
        if (isActivated)
        {
            isActivated = false;
            // Insert your switch logic here (e.g. open door)
        }
    }
}
