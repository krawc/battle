using UnityEngine;
using System.Collections;

public class EnemyTankShoot : MonoBehaviour {

	private bool justSpawned;
	public GameObject bullet;
	private Vector2 minMax;
	private Vector3 randPos;

	// Update is called once per frame
	void Start () {
		shootNews ();
	}

	void Update () {

		if (justSpawned) {
			Invoke("shootNews", 1);
			justSpawned = false;
		}

	}

	public void shootNews() {
		Vector3 randPos = new Vector3(Random.Range (-200, 200), 0.2f, Random.Range (-200, 200));
		Instantiate (bullet, randPos, Quaternion.identity);
		justSpawned = true;
	}
}