using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f; //[SerializeField] dùng để hiện biến ra tab cho tiện chỉnh sửa tương tự như public
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling } //Tạo một dạng dữ liệu riêng cho di chuyển

    [SerializeField] private AudioSource jumpSFX;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Space to Jump
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jumpSFX.Play();
            Jump();
        }

        //Run
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        UpdateAnimation();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); //rb.velocity.x sử dụng để giữ tọa độ X hiện tại của nhân vật
    }

    private void UpdateAnimation()
    {
        MovementState state;
        //Check running animation
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        //Check jumping animation
        if (rb.velocity.y > .1f) //Đặt 0.1 vì tọa độ y hầu hết luôn lớn hơn 0
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int) state);
    }

    //Kiểm tra vật lý, nhận diện nhân vật có chạm vào mặt đất không
    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
