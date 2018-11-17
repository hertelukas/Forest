using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    public Animator animator;
    public float walking;
    public float turning;
    public float jump;
    public float jumpLeg;
    public bool crouch = false;

    float horizontalSpeed = 2.0f;
    float verticalSpeed = 2.0f;

    private Vector3 rotateValue;

    public Camera Camera;

    void Start ()
    {
        animator = this.gameObject.GetComponent<Animator>();

    }

    void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = -0.5f * (verticalSpeed * Input.GetAxis("Mouse Y"));
        //v = Mathf.Clamp(v, -150, 150);

        rotateValue = new Vector3(v, 0, 0);
        Camera.transform.Rotate (rotateValue);
       
        walking = Input.GetAxis("Vertical") / 2;
        turning = h;


        if (Input.GetKey(KeyCode.Y))
        {
            crouch = true;
            walking = walking / 3;
        }
        else
        {
            crouch = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            walking = walking * 2;
        }

        jump = 0;

        if (Input.GetKey(KeyCode.Space))
        {
            jump = 5f;
        }


        animator.SetFloat("Forward", Mathf.Abs(walking));
        //animator.SetFloat("Turn", turning);
        animator.SetBool("Crouch", crouch);
        animator.SetFloat("Jump", jump);
        animator.SetFloat("JumpLeg", jumpLeg);


        transform.Translate (0f, 0f, walking * 10 * Time.deltaTime);
        transform.Rotate(0f, turning, 0f);
	}
}
