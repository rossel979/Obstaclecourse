using UnityEngine;

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
                Debug.Log("gratz fin");
                break;
            case "fuel":
                Debug.Log("fuel collected");
                break;
            default:
                Debug.Log("Sorry, blew up");
                break ;
        }
    }
}
