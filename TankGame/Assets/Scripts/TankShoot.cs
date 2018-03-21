using UnityEngine;
using System.Collections;

public class TankShoot : MonoBehaviour {

	public GameObject bullet, spawnPosObj;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(0))
		{
			for (int i = 0; i < 10; i++) {
				Instantiate (bullet, spawnPosObj.transform.position, Quaternion.Euler(0,(36*i),0));
			}
		}
	}
}
