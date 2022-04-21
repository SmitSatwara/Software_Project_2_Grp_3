using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    public bool dirRight = true;

    public float runSpeed;
    public float walkSpeed;
    public float moveSpeed;
    public float crouchSpeed;

    public Transform weaponPos;
    public Transform rightShoulder;

    GameObject rsRef;

    public Vector3 offsetWeapon;


   
  
    private Transform detectedPlayer;
    private NavMeshAgent mAgent;

    public bool attack = false;
    public float attackDistance;

    public bool isDead = false;
    public bool IsAIPlayer = true;
    public Transform groundCheckPos;
   //rivate float groundRadius = 0.1f;
    Collider[] groundColliders;
    public LayerMask GroundLayer;

    public bool isGrounded = true;
    public float jumpSpeed = 5;

    //public Inventory inventory;
    void Start()
    {
        mAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        rsRef = new GameObject("IK Helper");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        NPCMove();
        
        ShoulderHandler();
    }

    void NPCMove()
    {
        if (isDead)
            return;

        anim.SetBool("IsGrounded", isGrounded);

        if (IsAIPlayer && detectedPlayer != null && mAgent != null)
        {
            moveSpeed = runSpeed;
            mAgent.SetDestination(detectedPlayer.transform.position);

            if (detectedPlayer.transform.position.x < transform.position.x && dirRight)
            {
                ChangeDirection();
            }
            else if (detectedPlayer.transform.position.x > transform.position.x && !dirRight)
            {
                ChangeDirection();
            }

            float dist = Vector3.Distance(detectedPlayer.transform.position, transform.position);
            if (Mathf.Abs(dist) <= attackDistance)
            {
                attack = true;
            }
            else if (Mathf.Abs(dist) > attackDistance)
            {
                attack = false;
            }

            float animVal = mAgent.velocity.x / mAgent.speed;
            anim.SetFloat("Speed", Mathf.Abs(animVal));
        }

    }

    public void Death()
    {
        anim.Play("Death");
        detectedPlayer = null;
        attack = false;
        isDead = true;

    }

        

    void ShoulderHandler()
    {
        Vector3 rightShoulderPos = rightShoulder.TransformPoint(Vector3.zero);
        rsRef.transform.position = rightShoulderPos;
        rsRef.transform.parent = transform;

        weaponPos.transform.position = rsRef.transform.position + offsetWeapon;

    }

    void ChangeDirection()
    {
        dirRight = !dirRight;
        Vector3 PlayerRotation = transform.rotation.eulerAngles;
        PlayerRotation.y *= -1;
        transform.eulerAngles = PlayerRotation;
        offsetWeapon.z *= -1;
        offsetWeapon.x *= -1;
    }


    public void EnemyDetected(Transform player)
    {
        detectedPlayer = player;
    }

}