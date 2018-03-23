using UnityEngine;
using System.Collections;


public class BulletHit : MonoBehaviour
{
	private ModalPanel modalPanel;
	private DisplayManager displayManager;
	public int counter;
	public int truth;
	private bool updated;
	private int aff1;
	private int aff2;
	private int playerAff1;
	private int playerAff2;
	public int queCount;

	string[] dem = new string[] {
		"The Progressive president signed an executive order banning all fake news outlets. Amazing!", 
		"Conservative campaign leaders offered actors $50 to cheer during events. That's just sad.", 
		"Conservatives claimed climate change was a hoax created by China.",
		"Conservatives issued a 90-day executive order banning childhood vaccinations.",
		"North Korean cats rounded up and sent south",
		"The president throws dance party to celebrate North Korea missile launch",
		"Conservatives will repeal same-sex marriage. Gross."
	};
	string[] rep = new string[] {
		"The Progressives Ordered the Shutdown to Stage a Coup. Outrageous!", 
		"The Pope backed our candidate. So happy!", 
		"Climate change is just a hoax.",
		"The Progressives want to legalize incest marriages. The world is coming to an end.",
		"The progressive senator throws dance party to celebrate North Korea missile launch",
		"They are just satanists.",
		"The MMR vaccine gave me hypochondria."
	};

	string[] que = new string[] {
		"Did the progressives really the Shutdown to Stage a Coup?", 
		"How do they know Pope backed up their candidate?", 
		"What is the evidence for and against climate change? Which side is more credible?",
		"Do really all Progressives want to legalize incest?",
		"What is the source of that page on North Korea?",
		"Is it okay to make blanket statements on entire social groups?",
		"Is it the MMR vaccine or just my hypochondria?",
		"How do we ban fake news? Is that even possible?", 
		"Is anecdotal evidence enough?", 
		"Maybe it's just more plausible cause it sounds like a conspiracy?",
		"What if some news are made to make me angry?",
		"And what if some of it is simply fake?",
		"Do I really have to stick to my group?",
		"Or maybe searching for truth is more important than keeping the validation score up?"
	};
	void Start ()
	{
		queCount = 0;
	}
	void Update() {
		if (updated == true) {
			counter++;
			updated = false;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		modalPanel = ModalPanel.Instance ();
		displayManager = DisplayManager.Instance ();


		if (other.tag == "Player") {
			//Destroy(other.gameObject);

			PlayerAffiliation playerAffiliation = other.GetComponent<PlayerAffiliation> ();
			PlayerHealth playerHealth = other.GetComponent<PlayerHealth> ();
			EnemyAffiliation enemyAffiliation = GetComponent<EnemyAffiliation> ();

			if (playerAffiliation != null) {
				playerAff1 = playerAffiliation.affiliation1;
				playerAff2 = playerAffiliation.affiliation2;
				queCount = playerAffiliation.queCounter;
			}
			if (enemyAffiliation != null) {
				aff1 = enemyAffiliation.affiliation1;
				aff2 = enemyAffiliation.affiliation2;
			}

			if (playerHealth != null) {
				truth = playerHealth.truth;
			}
			if (truth > 0) {
				if (aff1 == 1) {
					modalPanel.Choice (dem [Random.Range (0, 6)]);
					playerHealth.DecreaseTruth (Random.Range (-10, 30));
					if (aff1 != playerAff1) {
						playerHealth.DecreaseHealth (20);
					}
				} else if (aff2 == 1) {
					modalPanel.Choice (rep [Random.Range (0, 5)]);
					playerHealth.DecreaseTruth (Random.Range (-10, 30));
					if (aff2 != playerAff2) {
						playerHealth.DecreaseHealth (20);
					}
				} else if (gameObject.tag == "Bullet") {
					modalPanel.Choice (que [queCount]);
					playerHealth.DecreaseTruth (Random.Range (-50, 0));
					playerAffiliation.incQueCount ();
				}
				if (playerAffiliation != null) {
					playerAffiliation.functionCalled = false;

				}
				updated = true;
			} else {
				modalPanel.Choice ("You don't seem to get to the truth. What if you abandon the group and ask questions?")
			}
//			if (playerHealth != null) {
//
//
//			} else {
//				Debug.LogWarning ("No PlayerHealth found on EnemyTank.");
//			}
			//Destroy (this.gameObject);


		} 
	}
}
