using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float fireRate;
    public float range;
    public float damageAmt;
    public GameObject muzzleFlash;
    public GameObject bulletTracer;

    public PlayerHealth pHealth;
    public EnemyHealth eHealth;

    public Transform muzzleFlashPostion;
    public Transform firePosition;
    public Transform bulletTracerPosition;

    public AudioClip fireSoundClip;
    private AudioSource fireSoundSource;
    public int EnemyCounter = 0;
    private CharacterControll ref_CC;


    public float fireTime=0.0f;
    // Start is called before the first frame update
    void Start()
    {
        pHealth = GetComponentInParent<PlayerHealth>();
        eHealth = GetComponentInParent<EnemyHealth>();
        ref_CC = GetComponentInParent<CharacterControll>();
        fireSoundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(Input.GetKey(KeyCode.Mouse0) /*Input.GetKeyDown(KeyCode.X)*/ )
        {
            Fire();
            
        }
        /*if (ref_CC.IsAIPlayer && ref_CC.attack)
        {
            Fire();
        }*/
        fireTime += Time.deltaTime;
    }

    void Fire()
    {
        if (fireTime < fireRate)
            return;

        RaycastHit hit;

        Debug.DrawRay(firePosition.position, firePosition.forward * range, Color.red);
        if (Physics.Raycast(firePosition.position, firePosition.forward*range, out hit))
        {
            if(hit.collider.tag == "Enemy" )
            {
                var health = hit.transform.GetComponent<EnemyHealth>();
                health.Damage(damageAmt);

                if(health.currentHealth<0)
                {
                    EnemyCounter++;
                }
            }

            //if (hit.collider.tag == "Player")
            //{
            //    var health = hit.transform.GetComponent<PlayerHealth>();
            //    health.Damage(damageAmt);

                
            //}

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
