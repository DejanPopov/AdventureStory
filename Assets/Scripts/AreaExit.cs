﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//For scenes
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{

    public string areaToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Trigger when player enters the box collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        //In Unity we have taggeed player with "Player"
        if (other.tag == "Player")
        {
            //Scene manager load scene
            SceneManager.LoadScene(areaToLoad);
        }  
    }

}
 