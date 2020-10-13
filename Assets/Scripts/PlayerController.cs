using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Rigidbody is component for charater movement.We reference that.
    //Slide Rigidbody into the script we made in Unity.
    //Public because Unity can't see "private".
    public Rigidbody2D rigidBody;

    //GetAxisRaw is taking float value.
    //This will be shown in Unity to set.
    public float moveSpeed;

    //Reference to animator,put Animator in script in Unity.
    public Animator animator;

    //Static means there can only be one version of this for rvry single object.
    public static PlayerController instance;

    //For player when goes into other area that he doesnt spawn in
    //the middle of map rather then the point where he transitioned
    public string areaTransitionName;

    // Start is called before the first frame update.
    void Start()
    {
        //Playing game for first time,setting instance.
        //When player goes from scene 1 to 2 and back to 1, there is 2 players.
        //This IF/ELSE is to stop that.
        if (instance == null)
        {
            //instance = this script!
            instance = this;
        }
        else
        {
            //Destroy other player spawn
            Destroy(gameObject);
        }
        
        //When we load a new scene, don't destroy whatever is brackets.
        //When player exits scene and goes into other scene he doesn't exit.
        //gameObject in this case is the player,because this script is attached on him..
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //GetAxisRaw is better then GetAxis.
        //Here we get inputs from player,Unity has it that its (wasd) or arrow keys.

        /*  Vector2(Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")) is multiplayed by moveSpeed because
            character is moving slowly
        */
        rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")) * moveSpeed;

        //Setting float values ( like we set moveX and moveY in Unity).
        animator.SetFloat("moveX", rigidBody.velocity.x);
        animator.SetFloat("moveY", rigidBody.velocity.y);

        //Storing the last value if player moved the character,
        //so aniamtor will know whick animations to trigger.
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1
            || Input.GetAxisRaw("Vertical") == -1 || Input.GetAxisRaw("Vertical") == 1)
        {
            animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }
} 