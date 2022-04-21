using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun: MonoBehaviour, IInventoryItem
{
    public string Name
    {
        get 
        { 
            return "Gun"; 
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

