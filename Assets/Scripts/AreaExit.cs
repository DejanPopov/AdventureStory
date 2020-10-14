using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//For scenes
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{

    public string areaToLoad;

    public string areaTranstitionName;

    //AreaEntrance script instance
    public AreaEntrance theEntrance;

    //UI fading to load
    public float waitToLoad = 1f;
    private bool shouldLoadAfterFade;

    // Start is called before the first frame update
    void Start()
    {
        theEntrance.transtionName = areaTranstitionName;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;

            if (waitToLoad <= 0)
            {
                shouldLoadAfterFade = false;
                SceneManager.LoadScene(areaToLoad);
            }
        }
    }

    //Trigger when player enters the box collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        //In Unity we have taggeed player with "Player"
        if (other.tag == "Player")
        {
            //Scene manager load scene
            //SceneManager.LoadScene(areaToLoad);
            shouldLoadAfterFade = true;
            UIFade.instance.FadeToBlack(); 

            //This is from PlayerController.cs
            PlayerController.instance.areaTransitionName = areaTranstitionName;
        }  
    }

}
 