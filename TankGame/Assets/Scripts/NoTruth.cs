
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoTruth : MonoBehaviour {

	private bool show;
	public float health;
	public int truth;
	public GameObject player;
	public CanvasRenderer rend;
	public PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		playerHealth = player.GetComponent<PlayerHealth> ();
		rend = gameObject.GetComponent<CanvasRenderer>();
		GetComponent<RectTransform>().localScale = new Vector3(0,0);


	}

	// Update is called once per frame
	void Update () {
		if (playerHealth != null) {
			health = playerHealth.health;
			truth = playerHealth.truth;

		} else {
			Debug.LogWarning ("No PlayerHealth found on EnemyTank.");
		}
		if (truth <= 0) {
			GetComponent<RectTransform> ().localScale = new Vector3 (1000, 1000);
		} else {
			GetComponent<RectTransform> ().localScale = new Vector3 (0, 0);
		}
	}

	//	IEnumerator Blink ()
	//	{
	//		GetComponent<RectTransform>().localScale = new Vector3(1000,1000);
	//		yield WaitForSeconds(0.2);
	//		GetComponent<RectTransform>().localScale = new Vector3(0,0);
	//		//yield return new WaitForSeconds(1);
	//	}
}
