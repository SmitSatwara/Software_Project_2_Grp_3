using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float fireRate;
    public float range;
    public GameObject muzzleFlash;
    public GameObject bulletTracer;
   

    public Transform muzzleFlashPostion;
    public Transform firePosition;
    public Transform bulletTracerPosition;

    public AudioClip fireSoundClip;
    private AudioSource fireSoundSource;

    private CharacterControll ref_CC;

    public float fireTime=0.0f;
    // Start is called before the first frame update
    void Start()
    {
        ref_CC = GetComponentInParent<CharacterControll>();
        fireSoundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(ref_CC.IsAIPlayer && ref_CC.attack)
        {
            Fire();
        }
        if(Input.GetKeyDown(KeyCode.X) && !ref_CC.IsAIPlayer)
        {
            Fire();
        }
        fireTime += Time.deltaTime;
    }

    void Fire()
    {
        if (fireTime < fireRate)
            return;

        RaycastHit hit;

        if (Physics.Raycast(firePosition.position, firePosition.forward, out hit, range))
        {

        }

        GameObject MF;
        if (muzzleFlash != null)
        {
            MF = (GameObject)Instantiate(muzzleFlash, muzzleFlashPostion.position, muzzleFlashPostion.rotation,muzzleFlashPostion);
            Destroy(MF,0.25f);
        }
        GameObject BT;
        if (bulletTracer != null)
        {
            BT = (GameObject)Instantiate(bulletTracer, bulletTracerPosition.position, bulletTracerPosition.rotation,bulletTracerPosition);
            Destroy(BT, 0.25f);
        }

        if(fireSoundSource!= null)
        {
            fireSoundSource.PlayOneShot(fireSoundClip);
        }
        fireTime = 0.0f;
       
    }
}
