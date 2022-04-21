using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KillCounter : MonoBehaviour
{
    public TMP_Text killText;
    public Weapon cnt;

    void Update()
    {
        killText.text = cnt.EnemyCounter.ToString();
    }
}