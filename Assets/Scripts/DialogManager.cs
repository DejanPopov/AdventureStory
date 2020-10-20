using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UI
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogText;
    public Text nameText;
    public GameObject dialogBox;
    public GameObject nameBox;

    //Array of lines
    public string[] dialogLines;

    public int currentLine;

    //Making this script instance of itself for using in script DialogActivator
    public DialogManager instance;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //Test purpose
        //dialogText.text = dialogLines[currentLine];
    }

    // Update is called once per frame
    void Update()
    {
        //Open if dialog box is opened
        if (dialogBox.activeInHierarchy)
        {
            //If the left mouse click is pressed then we initiate dialog
            //We use GetButtonUp so the text will begin when player relases button
            //so it doesn't skip text ( if we used GetButton )
            if (Input.GetButtonUp("Fire1"))
            {
                currentLine++;

                //How many string are in array (dialogLines.Length)
                if (currentLine >= dialogLines.Length)
                {
                    dialogBox.SetActive(false);
                }
                else
                {
                    //Update the text beeing shown
                    dialogText.text = dialogLines[currentLine];
                }
            }
        }
    }

    public void ShowDialog()
    {

    }
}
