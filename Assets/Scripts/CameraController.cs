using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Tilemap
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    //Find postion of player and move camera to that position
    public Transform target;

    //Finding size of map,so we can limit camera movement.
    //Camera needs to stop and not show the limits of map.
    public Tilemap theMap;
    private Vector3 botomLeftLimit;
    private Vector3 topRightLimit;

    //This is to eliminate the camera from showing as other than map
    private float halfHeight;
    private float halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        //Finding target (player)
        target = PlayerController.instance.transform;

        //Height of the camera.
        halfHeight = Camera.main.orthographicSize;
        //Aspect ration camera
        halfWidth = halfHeight * Camera.main.aspect;
        
        //Asign map,add in Unity under camera --> Tilemap --> Ground layer
        // -halfWidth and -halfHeight so camera doesnt go out of boundries
        botomLeftLimit = theMap.localBounds.min + new Vector3(halfWidth, halfHeight, 0f);
        topRightLimit = theMap.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0f);

        //Bounds of the maps are here as values
        PlayerController.instance.SetBounds(theMap.localBounds.min, theMap.localBounds.max);
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

        //Keep the camera inside the bounds
        //Matf.Clamp will clamp two points (in this case min and max of map).
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, botomLeftLimit.x, 
            topRightLimit.x), Mathf.Clamp(transform.position.y, botomLeftLimit.y, 
            topRightLimit.y), transform.position.z);
    }
}
