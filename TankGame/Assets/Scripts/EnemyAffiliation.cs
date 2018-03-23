using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyAffiliation : MonoBehaviour
{
	public int affiliation;
	public int affiliation1;
	public int affiliation2;
	public Vector3 position;
	public Renderer rend;
	public Color altColor = Color.black;

	// Use this for initialization
	void Start ()
	{

	affiliation1 = 0;
	affiliation2 = 0;

	position = transform.position;

	affiliation = 0;

		if (position.x <= 0) {
			affiliation1 = 1;
			affiliation2 = 0;
		} else if (position.x > 0) {
			affiliation1 = 0;
			affiliation2 = 1;
		} 


//		switch (transform.position.x)
//		      {
//		          case 0:
//		              affiliation1 = 1;
//		              break;
//		          case 2:
//		              affiliation2 = 1;
//		              break;
//		          default:
//		              affiliation1 = 1;
//		              break;
//		      }
		rend = GetComponent<Renderer>();
	}

	void Update(){



		altColor.r = affiliation1;
		altColor.b = affiliation2;
		altColor.a = 1;

		//Assign the changed color to the material.
		rend.material.color = altColor;
	}
}
