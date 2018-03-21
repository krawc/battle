using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			//Destroy(other.gameObject);

			PlayerHealth playerHealth = other.GetComponent<PlayerHealth> ();
			if (playerHealth != null) {
				playerHealth.DecreaseHealth (5);
			} else {
				Debug.LogWarning ("No PlayerHealth found on EnemyTank.");
			}
			Destroy (this.gameObject);
		} else if (other.tag == "EnemyTank") {
			EnemyHealth enemyHealth = other.GetComponent<EnemyHealth> ();
			if (enemyHealth != null) {
				enemyHealth.DecreaseHealth();
			} else {
				Debug.LogWarning ("No PlayerHealth found on EnemyTank.");
			}
			Destroy (this.gameObject);

		}
	}
}
