using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class SlimeController : MonoBehaviour {

    [SerializeField]
    private int speed;

    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	
	}

    void FixedUpdate()
    {
        Vector3 moveDirection = player.transform.position - gameObject.transform.position;
        moveDirection.Normalize();
        gameObject.GetComponent<Rigidbody>().AddForce(moveDirection * speed * Time.fixedDeltaTime);

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
