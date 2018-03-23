using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Collections;


public class PlayerAffiliation : MonoBehaviour
{
	public int affiliation;
	public int affiliation1;
	public int affiliation2;
	public int newAff;
	public int avg;
	public int counter;
	public bool functionCalled;
	public int queCounter;
	public Renderer rend;
	public Color altColor = Color.black;
	private ModalPanel modalPanel;
	private DisplayManager displayManager;
	private int affil1;
	private int affil2;
	private UnityAction myYesAction;
	private UnityAction myNoAction;
	private UnityAction myCancelAction;
	public GameObject bottom;


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

		affiliation1 = 1;
		affiliation2 = 0;
		queCounter = 0;

//		affiliation = UnityEngine.Random.Range (1, 2);
		rend = GetComponent<Renderer>();
		PlayerHealth playerHealth = GetComponent<PlayerHealth>();

		functionCalled = false;

		StartCoroutine (ChangeAffiliation ());

	}



	void Update(){


		modalPanel = ModalPanel.Instance ();
		displayManager = DisplayManager.Instance ();
		PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyTank");

		avg = 0;
		counter = 0;



		foreach(GameObject target in enemies) {
			if (target != null) {
				float distance = Vector3.Distance (target.transform.position, transform.position);
				EnemyAffiliation nme = target.GetComponent<EnemyAffiliation> ();
				if (nme != null) {
					affil1 = nme.affiliation1;
					affil2 = nme.affiliation2;

					if (distance < 10) {
						avg += affil1;
						avg -= affil2;
						counter++;
					}
				}
			}
		}
		if (counter != 0) {

			ChangeAffiliation ();

			if ((avg > 0) && (affiliation1 == 1)) {
				
				playerHealth.IncreaseHealth ();

				if (!functionCalled) {
					Invoke ("urSafe", 4f);
					functionCalled = true;
				}

			} else if ((avg < 0) && (affiliation2 == 1)) {
				
				playerHealth.IncreaseHealth ();

				if (!functionCalled) {
					Invoke ("urSafe", 4f);
					functionCalled = true;
				}
			} else {
					playerHealth.DecreaseHealth (0.2f);
				if (functionCalled) {
					Invoke ("urNot", 1f);
					functionCalled = true;
				}
			}

				
		} else {

				playerHealth.DecreaseHealth (0.2f);
			if (functionCalled) {
				Invoke ("urNot", 1f);
				functionCalled = true;
			}
		}

		altColor.r = affiliation1;
		altColor.g = 0;
		altColor.b = affiliation2;
		altColor.a = 1;

		//Assign the changed color to the material.
		rend.material.color = altColor;



//		bottom = this.gameObject.transform.GetChild(0).gameObject;
//		Renderer renderer = bottom.GetComponent<Renderer> ();
//		renderer.material.color = altColor;

	}

	IEnumerator ChangeAffiliation() {
		yield return new WaitForSeconds(10);

		if (avg > 0) {
			affiliation1 = 1;
			affiliation2 = 0;
		} else if (avg < 0) {
			affiliation1 = 0;
			affiliation2 = 1;
		}
	}

	void urSafe() {
		modalPanel.Choice ("You are safe. Connect with your friends and the world around. Mind the truth count.");
		functionCalled = true;
	}

	void urNot() {
		modalPanel.Choice ("You're too far from your group! Go back immediately! Or...");
	}
	public void incQueCount() {
		queCounter++;
	}
}
