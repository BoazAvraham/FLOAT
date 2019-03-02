using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed=10f;
    public float jumpSpeed=30f;
    public float blink = 100f;
    public float sensHorizontal = 10f;

    public float fallMultiplier = 3f;

    private Rigidbody rb;
    private bool canJump = true;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);


        //rb.AddForce(movement * speed);
        rb.position += transform.TransformDirection(movement) * speed * Time.deltaTime;


        if (Input.GetButtonDown("Jump") && canJump) {
            rb.velocity += new Vector3(0f, jumpSpeed, 0f);
            canJump = false;
        }

        //if (rb.velocity.y < 0) {
        //    rb.velocity+= Vector3.up * fallMultiplier*Physics.gravity.y*Time.fixedDeltaTime;
        //}
        //mouse rotation
        transform.Rotate(0f, Input.GetAxis("Mouse X") * sensHorizontal, 0f);

        if (Input.GetButtonDown("Boost")) {
            transform.position += transform.TransformDirection(movement) * blink * Time.deltaTime;
        }

        //StartCoroutine(debugVel());
    }

    void OnCollisionEnter(Collision other) {
        if (other.transform.position.y < transform.position.y)
            canJump = true;
    }

    private IEnumerator debugVel() {
        Debug.Log(rb.velocity);
        yield return new WaitForSeconds(2);
    }
}
