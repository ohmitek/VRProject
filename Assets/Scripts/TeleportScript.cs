using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject smartphoneObject;

    private bool smartphoneInsideTrigger = false;
    private float timeInsideTrigger = 0f;
    private Vector3 initialPlayerPosition;

    void Start()
    {
        if (playerObject != null)
        {
            initialPlayerPosition = playerObject.transform.position;
            Debug.Log("Position saved!");
        }
        else
        {
            Debug.LogError("Player object reference not set. Assign the player object in the inspector.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == smartphoneObject || other.gameObject == playerObject)
        {
            smartphoneInsideTrigger = true;
            Debug.Log("Smartphone entered the collision");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (smartphoneInsideTrigger)
        {
            timeInsideTrigger += Time.deltaTime;

            if (timeInsideTrigger >= 2f)
            {
                TeleportPlayerBack();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == smartphoneObject || other.gameObject == playerObject)
        {
            smartphoneInsideTrigger = false;
            timeInsideTrigger = 0f; // Reset the timer when the smartphone or player exits the trigger
        }
    }

    void TeleportPlayerBack()
    {
        if (playerObject != null)
        {
            Vector3 translation = initialPlayerPosition - playerObject.transform.position;
            playerObject.transform.Translate(translation);
        }
        else
        {
            Debug.LogError("Player object reference not set. Assign the player object in the inspector.");
        }

        // Reset variables
        smartphoneInsideTrigger = false;
        timeInsideTrigger = 0f;
    }

}

