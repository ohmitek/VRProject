using UnityEngine;

public class CloseVRGame : MonoBehaviour
{
    private void Update()
    {
        // Check if the ESC key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseGame();
        }
    }

    private void CloseGame()
    {
        // Quit the application (may not work with all VR games)
        Application.Quit();
    }
}

