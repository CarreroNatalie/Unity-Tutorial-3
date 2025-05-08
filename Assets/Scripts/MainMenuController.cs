using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Start");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure XR rig or its collider is tagged "Player"
        {
            SceneManager.LoadScene("Start");
        }
    }
}
