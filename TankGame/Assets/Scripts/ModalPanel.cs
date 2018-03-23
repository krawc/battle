using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class ModalPanel : MonoBehaviour {

	public Text question;
	public GameObject modalPanelObject;
	public float displayTime;
	public float fadeTime;

	private IEnumerator fadeAlpha;

	private static ModalPanel modalPanel;

	public static ModalPanel Instance () {
		if (!modalPanel) {
			modalPanel = FindObjectOfType(typeof (ModalPanel)) as ModalPanel;
			if (!modalPanel)
				Debug.LogError ("There needs to be one active ModalPanel script on a GameObject in your scene.");
		}

		return modalPanel;
	}

	// Yes/No/Cancel: A string, a Yes event, a No event and Cancel event
	public void Choice (string question) {
		modalPanelObject.SetActive (true);

		this.question.text = question;
		SetAlpha ();
	}

	void SetAlpha () {
		if (fadeAlpha != null) {
			StopCoroutine (fadeAlpha);
		}
		fadeAlpha = FadeAlpha ();
		StartCoroutine (fadeAlpha);
	}

	IEnumerator FadeAlpha () {
		Color resetColor = question.color;
		resetColor.a = 1;
		question.color = resetColor;

		yield return new WaitForSeconds (displayTime);

		while (question.color.a > 0) {
			Color displayColor = question.color;
			displayColor.a -= Time.deltaTime / fadeTime;
			question.color = displayColor;
			yield return null;
		}
		yield return null;
	}

//	void ClosePanel () {
//		modalPanelObject.SetActive (false);
//	}
}