using UnityEngine;
using UnityEngine.SceneManagement;

public class WinDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the tag "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected! Loading LevelComplete scene...");
            SceneManager.LoadScene("LevelComplete");
        }
    }
}