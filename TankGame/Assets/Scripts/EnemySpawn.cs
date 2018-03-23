using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	private bool justSpawned;
	public GameObject enemy;
	private Vector2 minMax;


	// Use this for initialization
	void Start () {
		SpawnEnemy ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (justSpawned) {
			Invoke("SpawnEnemy", 10);
			justSpawned = false;
		}

	}

	/* Spawn a enemy at a random position on the map. */
	public void SpawnEnemy()
	{
		Vector3 randPos = new Vector3(Random.Range (20, 60),
		                              0.5f,
		                              Random.Range (-10, 10));
		Vector3 randPos2 = new Vector3(Random.Range (-30, -10),
			0.5f,
			Random.Range (-60, 0));

		
		Instantiate (enemy, randPos, Quaternion.identity);
		Instantiate (enemy, randPos2, Quaternion.identity);

		justSpawned = true;
	}
}
