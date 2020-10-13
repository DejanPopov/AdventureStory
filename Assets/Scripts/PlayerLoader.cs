using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    //We want to load gameObject (that is player).
    //Thats why we dont use here PlayerController.
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerController.instance == null)
        {
            //If there is no player in this world,instantiate one.
            Instantiate(player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
