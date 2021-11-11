using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 8f;
    private Vector3 dir;
    private Rigidbody2D rd;
    public Animator anim;
    public bool isGround = false;
    public int jumpNum = 0;

    public KeyCode Lef = KeyCode.A;
    public KeyCode Righ = KeyCode.D;
    public KeyCode Jump = KeyCode.Space;
    // Start is called before the first frame update
    void Start()
    {
        rd = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        jump();
    }

    private void Move()
    {
        if (Input.GetKey(Lef))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            anim.SetFloat("running", 1);
        }
        else if (Input.GetKey(Righ))
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            anim.SetFloat("running", 1);
        }
        else anim.SetFloat("running", 0);
    }

    public float JumpHeight
    {
        set => jumpVelocity = new Vector2(0, Mathf.Sqrt(value * -Physics2D.gravity.y * 2));
    }

    private Vector2 jumpVelocity;

    public void jump()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, 1 << 6);
        if (hit.collider != null)
        {
            isGround = true;
            jumpNum = 0;
        }
        else isGround = false;
        if (!isGround && jumpNum == 2) return;
        bool is_jump = Input.GetKeyDown(Jump);
        if (is_jump) jumpNum++;
        if (rd.velocity.y >= 0)
            anim.SetFloat("jum", rd.velocity.y);
        else anim.Play("drop");
        if (is_jump)
        {
            JumpHeight = 50;
            rd.velocity = jumpVelocity;
        }
    }
}
