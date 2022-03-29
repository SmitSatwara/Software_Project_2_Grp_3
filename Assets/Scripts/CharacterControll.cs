using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterControll : MonoBehaviour
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


    public bool IsCrouch= false;

    public bool IsAIPlayer = false;
    private Transform detectedPlayer;
    private NavMeshAgent mAgent;

    public Transform groundCheckPos;
    private float groundRadius = 0.1f;
    Collider[] groundColliders;
    public LayerMask GroundLayer;

    public bool isGrounded = true;
    public float jumpSpeed=5;
    void Start()
    {
        if (IsAIPlayer)
        {
            mAgent = GetComponent<NavMeshAgent>();
        }
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        rsRef = new GameObject("IK Helper");
    }
    // Update is called once per frame
    void FixedUpdate()   
    {
        NPCMove();
        PlayerMove();
        ShoulderHandler();
    }

    void NPCMove()
    {
        anim.SetBool("IsGrounded", isGrounded);

        if(IsAIPlayer && detectedPlayer != null && mAgent!=null)
        {
            moveSpeed = runSpeed;
            mAgent.SetDestination(detectedPlayer.transform.position);

            if(detectedPlayer.transform.position.x < transform.position.x && dirRight)
            {
                ChangeDirection();
            }else if(detectedPlayer.transform.position.x > transform.position.x && !dirRight)
            {
                ChangeDirection();
            }
            float animVal = mAgent.velocity.x / mAgent.speed;
            anim.SetFloat("Speed",Mathf.Abs(animVal));
        }
        
    }
    void PlayerMove()
    {
        if (IsAIPlayer)
            return;
        
        float move = Input.GetAxis("Horizontal");
        if (move < 0 && dirRight)
        {
            ChangeDirection();
        }
        if (move > 0 && !dirRight)
        {
            ChangeDirection();
        }

        if (Mathf.Abs(move) >= 0.5 && !IsCrouch)
        {
            moveSpeed = runSpeed;

        }
        else if(Mathf.Abs(move) < 0.5 && !IsCrouch)
        {
            moveSpeed = walkSpeed;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            IsCrouch = !IsCrouch;
            moveSpeed = crouchSpeed;
           
        }

        if (Input.GetAxis("Jump") > 0 && !IsCrouch && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(new Vector3(0,jumpSpeed, 0));
        }
        else if(Input.GetAxis("Jump") > 0 && IsCrouch )
        {
            IsCrouch = false;
        }

        groundColliders = Physics.OverlapSphere(groundCheckPos.transform.position,groundRadius,GroundLayer);
        if(groundColliders.Length > 0)
        {
            isGrounded  = true;
        }
        else{
            isGrounded=false;
        }

        anim.SetBool("IsGrounded",isGrounded);

        anim.SetBool("IsCrouch", IsCrouch);
        float animValue = Mathf.Abs(move);

        anim.SetFloat("Speed", animValue);

        rb.velocity = new Vector3(move * moveSpeed, rb.velocity.y, 0);

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
        Vector3 PlayerRotation=transform.rotation.eulerAngles;
        PlayerRotation.y *= -1;
        transform.eulerAngles= PlayerRotation;
        offsetWeapon.z *= -1;
        offsetWeapon.x *= -1;
    }

    
    public void EnemyDetected(Transform player)
    {
        detectedPlayer = player;
    }
}
