using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public GameObject explosion;
	public float health, maxHealth, originalWidth;
	public int truth;
	public Image healthBar;
	private float boxWidth;
	public float barDisplay; //current progress
	public Vector2 pos = new Vector2(20,40);
	public Vector2 size = new Vector2(1000,10);
	public Texture2D emptyTex;
	public Texture2D fullTex;
	private GUIStyle currentStyle = null;
	private GUIStyle greenStyle = null;

	 
	void OnGUI() {
		InitStyles();
		//draw the background:
		GUI.Box( new Rect( 750, 360, 70, 30 ), truth.ToString(), currentStyle );
		GUI.Box( new Rect( 0, 0, 10 * health, 10 ), "Hello", greenStyle );
		//GUI.Box (new Rect (0, 0, 1000, 1000), "YOU ARE WRONG", currentStyle);


	}

	private void InitStyles()
	{
		GUI.skin.box.fontSize = 20;
		if( currentStyle == null )
		{
			currentStyle = new GUIStyle( GUI.skin.box );

//			GUI.skin.box.alignment = TextAnchor.MiddleCenter;
//
//			if (health <= 0) {
//				boxWidth = 0.0f;
//			}

			currentStyle.normal.background = MakeTex( 1, 1, new Color( 0f, 0f, 0f, 1f ) );

		}
		if( greenStyle == null )
		{
			greenStyle = new GUIStyle( GUI.skin.box );
			greenStyle.normal.background = MakeTex( 2, 2, new Color( 0f, 1f, 0f, 1f ) );
		}
	}

	private Texture2D MakeTex( int width, int height, Color col )
	{
		Color[] pix = new Color[width * height];
		for( int i = 0; i < pix.Length; ++i )
		{
			pix[ i ] = col;
		}
		Texture2D result = new Texture2D( width, height );
		result.SetPixels( pix );
		result.Apply();
		return result;
	}



	// Use this for initialization
	void Start ()
	{
		health = 100;
		maxHealth = 100;
		truth = 300;
		if (healthBar != null) {
			originalWidth = healthBar.transform.localScale.x;
		}
	}

	public void DecreaseHealth(float decrease)
	{
		health -= decrease; // health = health - 20;
		if (healthBar != null) {
			healthBar.transform.localScale = new Vector3((health / 100.0f) * originalWidth, 
			                                             healthBar.rectTransform.localScale.y,
			                                             healthBar.rectTransform.localScale.z);
		} else {
			Debug.LogWarning("HelthBar not found.");
		}




		if (health <= 0) {
			health = 0;
			//Instantiate (explosion, this.transform.position, Quaternion.Euler(-90, 0, 0));
			// Play Explosion Sound
			//Destroy (this.gameObject);
		}
	}



	public void IncreaseHealth()
	{
		health += 0.1f; // health = health - 20;

		if (health >= maxHealth) {
			health -= (health - maxHealth);
		}
	}

	public void DecreaseTruth(int decrease) {
		truth -= decrease;

	}
}
