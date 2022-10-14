using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemHudController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI itemText;
    
    public void TextUpdate(int value)
    {
        itemText.text = value.ToString();
    }
}
