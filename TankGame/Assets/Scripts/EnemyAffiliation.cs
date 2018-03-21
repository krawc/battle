using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyAffiliation : MonoBehaviour
{
	public int affiliation;
	public int affiliation1;
	public int affiliation2;
	public int affiliation3;
	public Renderer rend;
	public Color altColor = Color.black;

	// Use this for initialization
	void Start ()
	{

	affiliation1 = 0;
	affiliation2 = 0;
	affiliation3 = 0;

		affiliation = Random.Range (1, 4);
		      switch (affiliation)
		      {
		          case 1:
		              affiliation1 = 1;
		              break;
		          case 2:
		              affiliation2 = 1;
		              break;
		          case 3:
		              affiliation3 = 1;
		              break;
		          default:
		              affiliation1 = 1;
		              break;
		      }
		rend = GetComponent<Renderer>();
	}

	void Update(){



		altColor.r = affiliation1;
		altColor.g = affiliation2;
		altColor.b = affiliation3;
		altColor.a = 1;

		//Assign the changed color to the material.
		rend.material.color = altColor;
	}
}
