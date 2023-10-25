using UnityEngine;

public class JumpScript2 : MonoBehaviour
{
    public float jumpForce = 10f;
    public bool isGrounded;
    public Vector2 jump;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        jump = new Vector2(0.0f, 1.0f);
    }

    void OnCollisionStay2D()
    {
        isGrounded = true;
    }
    void OnCollisionExit2D()
    {
        isGrounded = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {

            GetComponent<Rigidbody2D>().AddForce(jump * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
}