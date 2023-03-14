using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [Header("health")]
    public int health;
    public int lives;
    [SerializeField]
    private bool isDead;


    [Header("Movment")]
    public float moveSpeed;
    public float x_input;
    public float y_input;
    public int facingDir;
    public bool isWalking;
    public Vector3 startpos;

    [Header("Jumping")]
    public float jumpForce;
    public int maxJumps;
    public int jumpcount;
    public bool isJumping;

    [Header("shooting")]
    public float shootSpeed;
    public GameObject bulletPrefab;

    [Header("Components")]
    [SerializeField]
    private Rigidbody2D rig;
    [SerializeField]
    private Animator animator;
    private gameControllerScript gameControllerObject;

    [Header("Debug")]
    public bool debug;

    public int score;


    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        startpos = GameObject.FindGameObjectWithTag("startpoint").transform.position;
        gameControllerObject = FindObjectOfType<gameControllerScript>();
        transform.position = startpos;
        facingDir = 1;
        isDead = false;
        score = 0;
        lives = 3;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if(!isDead)
        {
            move();
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        // set animation state
        animator.SetBool("walking",isWalking);
        animator.SetBool("jumping", isJumping);
        animator.SetBool("die", isDead);

        if (!isDead)
        {
            if (rig.velocity.y <= 0)
            {
                if (isGrounded())
                {
                    reset_Jumps();
                }
            }

            //check for jumps
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump();
            }
        }

        

    }

    // collision methods
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("midpoint"))
        {
            startpos = collision.transform.position;
        }
        if(collision.CompareTag("Goal"))
        {
            gameControllerObject.next_Level();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    // player actions
    private void move()
    {
        x_input = Input.GetAxis("Horizontal");
        if(x_input != 0 && !isJumping)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        if (x_input > 0)
        {
            facingDir = 1;
        }
        else if(x_input < 0)
        {
            facingDir = -1;
        }
        rig.velocity = new Vector2(x_input*moveSpeed,rig.velocity.y);
        transform.localScale= new Vector2(facingDir,transform.localScale.y);

    }
    private void jump()
    {
        if(jumpcount > 0)
        {
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpcount--;
            isJumping = true;
        }

    }
    private void shoot()
    {

    }
    private void climb()
    {

    }
    private void duck()
    {

    }

    public void collect(int value) 
    {
        score += value;
    }

    IEnumerator waitfor(float dur)
    {
        float counter = dur;
        while(counter>=0)
        {
            counter -= Time.deltaTime;
            yield return null;
        }
        reset_player();




    }

    public void die()
    {
        lives--;
        isDead = true;
        StartCoroutine(waitfor(2f));
        if(lives <= 0)
        {
            
        }
    }

    public void reset_player()
    {
        isDead = false;
        transform.position = startpos;
    }

    // utility functions
    private bool isGrounded()
    {
        RaycastHit2D hitC = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y-.01f), Vector2.down, .05f);
        RaycastHit2D hitR = Physics2D.Raycast(new Vector2(transform.position.x+.25f, transform.position.y - .01f), Vector2.down, .05f);
        RaycastHit2D hitL = Physics2D.Raycast(new Vector2(transform.position.x-.25f, transform.position.y - .01f), Vector2.down, .05f);

        if (hitL )
        {
            if (hitL.collider.gameObject.CompareTag("Ground")){
                return true;
            }
        }
        if (hitR )
        {
            if (hitR.collider.gameObject.CompareTag("Ground"))
            {
                return true;
            }
        }
        if ( hitC)
        {
            if (hitC.collider.gameObject.CompareTag("Ground"))
            {
                return true;
            }
        }
        return false;
    }

    private void reset_Jumps()
    {
        isJumping = false;
        jumpcount = maxJumps;
    }


}
