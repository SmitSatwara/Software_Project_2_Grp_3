using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour, IInventoryItem
{
    public string Name
    {
        get 
        { 
            return "Treasure"; 
        }
    }

    public Sprite _Image = null;

    public Sprite Image
    {
        get 
        { 
            return _Image; 
        }
    }

    public void OnPickup()
    {
        this.gameObject.SetActive(false);
    }
}

