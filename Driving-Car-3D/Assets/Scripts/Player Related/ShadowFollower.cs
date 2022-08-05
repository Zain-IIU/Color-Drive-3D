using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ShadowFollower : MonoBehaviour
{
    public Transform objectToFollow;  // Player in your Case

    [SerializeField] private Vector3 offset;
     
    void Update () {
        // Create a new Vector 3 with the positions of object to follow. Substract offset from pos.z
        Vector3 myNewPos = new Vector3(objectToFollow.position.x + offset.x, objectToFollow.position.y + offset.y, objectToFollow.position.z + offset.z);
 
        // Set position of the scripts GameObject to the previous created postition
        transform.position = myNewPos;
    }
}
