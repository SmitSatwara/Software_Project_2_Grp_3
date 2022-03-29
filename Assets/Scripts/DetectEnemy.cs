using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemy : MonoBehaviour
{
    private CharacterControll ref_CharacterControl;
    // Start is called before the first frame update
    void Start()
    {
        ref_CharacterControl=GetComponentInParent<CharacterControll>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ref_CharacterControl.EnemyDetected(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
