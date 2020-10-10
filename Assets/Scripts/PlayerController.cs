using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Rigidbody is component for charater movement.We reference that.
    //Slide Rigidbody into the script we made in Unity.
    //Public because Unity can't see "private".
    public Rigidbody2D rigidBody;

    //GetAxisRaw is taking float value
    //This will be shown in Unity to set
    public float moveSpeed;

    //Reference to animator,put Animator in script in Unity
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GetAxisRaw is better then GetAxis
        //Here we get inputs from player,Unity has it that its (wasd) or arrow keys.

        /*  Vector2(Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")) is multyplayed by moveSpeed because
            character is moving slowly
        */
        rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")) * moveSpeed;
    }
} 