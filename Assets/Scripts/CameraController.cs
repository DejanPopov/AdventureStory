using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Find postion of player and move camera to that position
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        //Finding target (player)
        target = PlayerController.instance.transform;
    }

    // Update is called once per frame
    //LateUpdate() is so the camera wont be lagging when moving player.
    //It is called after Update().
    void LateUpdate()
    {
        //Set X,Y,Z values
        //Z value is camera. If we would make transform.position.z
        //into target.position.z, the camera would be too close to the game
        //and everything would be blue.
        transform.position = new Vector3(target.position.x,
            target.position.y, transform.position.z);
    }
}
