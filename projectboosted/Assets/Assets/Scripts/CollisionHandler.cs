using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float fltlevelLoadDelay = 2f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "friendly":
                Debug.Log("this thing is friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            case "fuel":
                Debug.Log("fuel collected");
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartSuccessSequence()
    {
        audioSource.PlayOneShot(success);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", fltlevelLoadDelay);
    }

    void StartCrashSequence()
    {
        audioSource.PlayOneShot(crash);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", 1f);
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
