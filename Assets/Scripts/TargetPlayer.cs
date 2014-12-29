using UnityEngine;
using System.Collections;

public class TargetPlayer : MonoBehaviour
{


	public float seeDistance;

	public float attackDistance;

	public float speed;

	private Transform target;

	public int HP = 1000;
	
	void Start ()
	{       
		target = GameObject.Find ("Flash").transform;
	}
	void OnCollisionEnter (Collision  MyCollision){
		if (MyCollision.gameObject.name == "Bullet(Clone)") {
			HP -= 400;
		}
	}
	
	void Update (){

		if (HP <= 0) {
			Destroy(gameObject);
		}
		if (Vector3.Distance (transform.position, target.transform.position) < seeDistance) {
			if (Vector3.Distance (transform.position, target.transform.position) > attackDistance) {

				transform.LookAt (target.transform);
				transform.Translate (new Vector3 (0, 0, speed * Time.deltaTime));
			}
		} else {

		}
	}
}