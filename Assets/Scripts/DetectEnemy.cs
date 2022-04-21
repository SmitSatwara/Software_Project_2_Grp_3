using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemy : MonoBehaviour
{
    private EnemyController ref_CharacterControl;
    // Start is called before the first frame update
    void Start()
    {
        ref_CharacterControl=GetComponentInParent<EnemyController>();
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
