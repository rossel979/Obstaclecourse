using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
     void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "friendly":
                Debug.Log("this thing is friendly");
                break;
            case "Finish":
                LoadNextLevel();
                break;
            case "fuel":
                Debug.Log("fuel collected");
                break;
            default:
                ReloadLevel();
                break;
        }
    }
    void LoadNextLevel()
    {
        int intcurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int intnextSceneIndex = intcurrentSceneIndex + 1;
        if (intnextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            intnextSceneIndex = 0;
        }
        SceneManager.LoadScene(intnextSceneIndex);
        
    }

    void ReloadLevel()
    {
        int intcurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(intcurrentSceneIndex);
    }
}
