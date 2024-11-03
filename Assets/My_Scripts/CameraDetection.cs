using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraDetection : MonoBehaviour
{
    public Material detectorRangeMaterial; 
    public float delayBeforeGameOver = 2f; 
    public DogMovement dogMovementScript; // Reference to the DogMovement script

    private void Start()
    {
        // Set the camera detection color to semi-transparent yellow at the start
        if (detectorRangeMaterial != null)
        {
            detectorRangeMaterial.color = new Color(1f, 1f, 0f, 0.45f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            string currentScene = SceneManager.GetActiveScene().name;

            // Change color to a semi-transparent red
                if (detectorRangeMaterial != null)
                {
                    detectorRangeMaterial.color = new Color(1f, 0f, 0f, 0.45f);
                }

            if (currentScene == "VigilanceScene")
            {
                Debug.Log("Player detected in VigilanceScene! Changing color and preparing to load GameOver scene...");

                // Invoke the game over sequence
                Invoke("LoadGameOverScene", delayBeforeGameOver);
            }
            else if (currentScene == "FearScene" && dogMovementScript != null)
            {
                Debug.Log("Player detected in FearScene! Triggering Dog movement...");
                
                // Trigger DogMovement script's action
                dogMovementScript.StartMovingDog();
            }
        }
    }

    private void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
        
        // Reset the material color to yellow for play mode
        if (detectorRangeMaterial != null)
        {
            detectorRangeMaterial.color = new Color(1f, 1f, 0f, 0.45f);
        }
    }
}
