/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * MoveTowards.cs
 * Script for moving a GameObject towards another GameObject. Also rotates the 
 * game object towards the target.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using UnityEngine;
using System.Collections;
using System;

public class MoveTowards : MonoBehaviour
{

	/* Float value for the speed at which to move and rotate. */
	public float speed = 0.0000000000000001f, rotSpeed = 90.0f;

	/* Get the rigidbody of this game object. */
	void Start()
	{
//		target = GameObject.FindGameObjectWithTag("Player");
		//InvokeRepeating("SetPos",0,0.3f);
	}

	/* Moves this object towards the target every frame. */
	void Update()
	{
		/* If the target has been set and still exists in the game. */

			/* Vector from this game object to the target. */
//			Vector3 targetDir = target.transform.position - this.transform.position;
//
//			/* Turn this object to face the target. */
//			Quaternion rotationAngle = Quaternion.LookRotation(targetDir);
//			transform.rotation = Quaternion.Slerp(this.transform.rotation, 
//			                                      rotationAngle, Time.deltaTime * rotSpeed);
//
//

		this.transform.Translate(Vector3.forward * speed * Time.deltaTime * 0.02f);


	}

}