using UnityEngine;
using System.Collections;

public class EnemyTankShoot : MonoBehaviour {

	public GameObject bullet;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(0))
		{
			for (int i = 0; i < 10; i++) {
				Instantiate (bullet, transform.position, Quaternion.Euler(0,(36*i),0));
			}
		}
	}
}