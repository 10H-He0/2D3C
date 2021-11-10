using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 10f;
    private Vector3 dir;
    private Rigidbody2D rd;
    public Animator anim;
    public bool isGround = false;
    public int jumpNum = 0;
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
        float horizontal = Input.GetAxis("Horizontal");
        float H = Mathf.Abs(horizontal);
        anim.SetFloat("running", H);
        dir = new Vector3(horizontal, 0).normalized;
        transform.Translate(dir * speed * Time.deltaTime);
        if (horizontal < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (horizontal > 0)
            transform.localScale = new Vector3(1, 1, 1);
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
        bool is_jump = Input.GetKeyDown(KeyCode.Space);
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
