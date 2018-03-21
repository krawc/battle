using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


public class PlayerAffiliation : MonoBehaviour
{
	public int affiliation;
	public int affiliation1;
	public int affiliation2;
	public int affiliation3;
	public int newAff;
	public int avg;
	public int counter;
	public Renderer rend;
	public Color altColor = Color.black;

    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].SendMessage("AddDamage");
            i++;
        }
    }

	// Use this for initialization
	void Start ()
	{

	affiliation1 = 0;
	affiliation2 = 0;
	affiliation3 = 0;

		affiliation = UnityEngine.Random.Range (1, 3);
		rend = GetComponent<Renderer>();
		PlayerHealth playerHealth = GetComponent<PlayerHealth>();

	}

	void Update(){

		avg = 0;
		counter = 0;

		switch (affiliation)
		{
		case 1:
			affiliation1 = 1;
			affiliation2 = 0;
			affiliation3 = 0;
			break;
		case 2:
			affiliation1 = 0;
			affiliation2 = 1;
			affiliation3 = 0;
			break;
		case 3:
			affiliation1 = 0;
			affiliation2 = 0;
			affiliation3 = 1;
			break;
		default:
			affiliation1 = 0;
			affiliation2 = 0;
			affiliation3 = 0;
			break;
		}

		PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();




		GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyTank");
		foreach(GameObject target in enemies) {
			float distance = Vector3.Distance(target.transform.position, transform.position);
			if(distance < 10) {
				newAff = FindObjectOfType<EnemyAffiliation> ().affiliation;
				avg += newAff;
				counter++;
			}
		}
		if (counter != 0) {
			float converted = avg / counter;
			int final = (int)Math.Round (converted);
			affiliation = final;
			playerHealth.IncreaseHealth ();
		} else {
			playerHealth.DecreaseHealth (0.5f);
		}

		altColor.r = affiliation1;
		altColor.g = affiliation2;
		altColor.b = affiliation3;
		altColor.a = 1;

		//Assign the changed color to the material.
		rend.material.color = altColor;
	}
		

}
