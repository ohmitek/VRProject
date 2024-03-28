using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadClassroomScene : MonoBehaviour
{
    public string LevelName;
    public AudioClip beepSound; // Assign the beep sound in the Unity editor
    public float delayBeforeSceneChange = 1.0f; // Adjust the delay before scene change

    private AudioSource audioSource;

    void Start()
    {
        // Add an AudioSource component to the GameObject
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Smartphone"))
        {
            // Play the beep sound
            if (beepSound != null)
            {
                audioSource.PlayOneShot(beepSound);
            }

            // Start the delayed scene change coroutine
            StartCoroutine(DelayedSceneChange());
        }
    }

    IEnumerator DelayedSceneChange()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforeSceneChange);

        // Load scene
        SceneManager.LoadScene(LevelName);
    }
}
