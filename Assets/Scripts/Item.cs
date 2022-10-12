using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    [SerializeField]
    private int itemQtd = 0;

    private ItemHudController hudController;

    private void Awake()
    {
        hudController = FindObjectOfType<ItemHudController>();
    }



    private void  OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coletavel")
        {
            itemQtd = itemQtd + 1;
            hudController.TextUpdate(itemQtd);
            Destroy(collision.gameObject);
        }
    }
    
        
    
}

