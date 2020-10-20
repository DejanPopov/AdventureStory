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


    // Start is called before the first frame update
    void Start()
    {
        dialogText.text = dialogLines[currentLine];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
