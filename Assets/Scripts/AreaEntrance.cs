using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    //For player to not to spawn in the middle of map.
    public string transtionName;

    // Start is called before the first frame update
    void Start()
    {
        //If player transtion name is as this transition name
        if (transtionName == PlayerController.instance.areaTransitionName)
        {
            //Then take position from player and put it where this script is attached.
            //more likely find this player and put him at this point.
            PlayerController.instance.transform.position = transform.position;
        }

        UIFade.instance.FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
