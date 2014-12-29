using UnityEngine;
using System.Collections;
public class Move : MonoBehaviour {

	public Transform player;
	public int speed;
	public int jumpImpulse;
	public bool isJump;

	void Start() {
		player = transform;
	}


	void Update(){
				
						if (Input.GetKey (KeyCode.W)) {
								player.rigidbody.AddForce(-player.forward * speed * Time.deltaTime, ForceMode.Impulse);
								
						}
						if (Input.GetKey (KeyCode.S)) {
								player.rigidbody.AddForce(player.forward * speed * Time.deltaTime, ForceMode.Impulse);
								
						}
						if (Input.GetKey (KeyCode.D)) {
								player.rigidbody.AddForce(-player.right * speed * Time.deltaTime, ForceMode.Impulse);
								
						}
						if (Input.GetKey (KeyCode.A)) {
								player.rigidbody.AddForce(player.right * speed * Time.deltaTime, ForceMode.Impulse);
								
						}
						if(Input.GetKey(KeyCode.Space) && !isJump){
							Jupm();
						}
				}

	void Jupm(){
		isJump = true;
		player.rigidbody.AddForce(Vector3.up * jumpImpulse * Time.deltaTime, ForceMode.Impulse);
	}

	void OnCollisionEnter(){
		isJump = false;
	}
}

