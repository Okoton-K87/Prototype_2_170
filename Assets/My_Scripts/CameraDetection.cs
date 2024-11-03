using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraDetection : MonoBehaviour
{
    public Material detectorRangeMaterial; 
    public float delayBeforeGameOver = 2f; 

    // Changes the camera detection color to yellow at the start
    private void Start()
    {
        if (detectorRangeMaterial != null)
        {
            detectorRangeMaterial.color = new Color(1f, 1f, 0f, 0.45f);
        }
    }

    // Changes the camera detection color to red when detected, delays game over screen so players can see the change
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected! Changing color and preparing to load GameOver scene...");

            if (detectorRangeMaterial != null)
            {
                detectorRangeMaterial.color = new Color(1f, 0f, 0f, 0.45f);
            }

            Invoke("LoadGameOverScene", delayBeforeGameOver);
        }
    }

    private void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
        // extra yellow changer, having it still be red in the scene after play mode bothered me
        if (detectorRangeMaterial != null)
        {
            detectorRangeMaterial.color = new Color(1f, 1f, 0f, 0.45f);
        }
    }
}
