using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public GameObject bullet;
	public float bulletImpulse;
	public float shootSpeed;
	public float lastShotTime;
	// Use this for initialization
	void Start () {
		lastShotTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Mouse0)) { 
			if (Time.time>(lastShotTime + shootSpeed)) { 
				GameObject bull_clone;
				bull_clone = Instantiate(bullet, transform.position, transform.rotation) as GameObject; 
				Physics.IgnoreCollision(bull_clone.collider, collider); 
				bull_clone.rigidbody.AddForce(transform.forward * bulletImpulse, ForceMode.Impulse); 
				lastShotTime = Time.time; 
				Destroy(bull_clone,2);
			} 
		}
	}
}
