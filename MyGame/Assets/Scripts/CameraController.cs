using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private Vector3 distanceFromPlayer;
    private GameObject player;

	// Use this for initialization
	void Start () {

        distanceFromPlayer = gameObject.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.position = player.transform.position + distanceFromPlayer;
        this.transform.rotation = player.transform.rotation;
	}
}
