﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    public string[] lines;

    private bool canActivate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canActivate && Input.GetButtonDown("Fire1") 
            && !DialogManager.instance.dialogBox.activeInHierarchy)
        {
            DialogManager.instance.ShowDialog(lines);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //If player enters box collider activate dialog box
        if (collision.tag == "Player")
        {
            canActivate = true;
        }
    }
}
