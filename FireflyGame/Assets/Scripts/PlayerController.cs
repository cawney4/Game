using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float walkingForce;

    [SerializeField]
    private float rotateSpeed;

    //[SerializeField]
    //private float doubleTapTime;

    private Animator animator;

    //private bool running;

    //private int doubleTapCount;

    //private float doubleTapCountdown;

	// Use this for initialization
	void Start () {
        //this.running = false;
        //this.doubleTapCount = 0;
        //this.doubleTapCountdown = 0;
        this.animator = gameObject.GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {

        //left click
        if (Input.GetMouseButtonDown(0))
        {
            this.animator.SetBool("attack", true);
        }

        /*
        if (Input.GetMouseButtonDown(1))
        {
            this.running = true;
            //animator.SetBool("run", true);
        }

        if (Input.GetMouseButtonUp(1))
        {
            this.running = false;
            //animator.SetBool("walk", true);
        }
        */

	}

    void FixedUpdate()
    {
        float z_axis = Input.GetAxis("Vertical");
        float x_axis = Input.GetAxis("Horizontal");

        if (x_axis != 0)
        {
            Vector3 rotation = new Vector3(0, x_axis * rotateSpeed * Time.fixedDeltaTime, 0);
            gameObject.transform.Rotate(rotation);
        }

        if (z_axis != 0) {

            //Vector3 movementZ = new Vector3(0f, 0f, z_axis * walkingForce * Time.fixedDeltaTime);
            //Vector3 movementX = new Vector3(x_axis * walkingForce * Time.deltaTime, 0f, 0f);

            //Debug.Log(movementZ);
            //gameObject.GetComponent<Rigidbody>().AddForce(movementZ);

            if (z_axis < 0.5)
            {
                Vector3 movementZ = new Vector3(0f, 0f, z_axis * walkingForce * Time.fixedDeltaTime);

                gameObject.GetComponent<Rigidbody>().AddForce(movementZ);
                //gameObject.transform.position = gameObject.transform.position.x.
                animator.SetBool("walk", true);
                animator.SetBool("run", false);
            }
            else if (z_axis >= 0.5)
            {
                animator.SetBool("run", true);
                animator.SetBool("walk", false);
            }
                
        }
        else {
            animator.SetBool("walk", false);
            animator.SetBool("run", false);
        }
    }

    public void AttackToIdle()
    {
        this.animator.SetBool("attack", false);
    }
}
