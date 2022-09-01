using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody;
    [SerializeField]
    float speed;
    [SerializeField]
    float forceJump;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rigidbody.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
        }

        if(Input.GetAxis("Horizontal") < 0)
            transform.eulerAngles = new Vector3(0, -180, 0);
        if (Input.GetAxis("Horizontal") > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);


    }

    public bool IsGrounded()
    {
        GameObject checkGround = GameObject.Find("checkground");
        var groundCheck = Physics2D.Raycast(checkGround.transform.position, Vector2.down, 0.3f);

        return groundCheck.collider != null && groundCheck.collider.CompareTag("Ground");
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector3(
            Input.GetAxis("Horizontal")*speed,
            rigidbody.velocity.y,
            0);

       
    }
}
