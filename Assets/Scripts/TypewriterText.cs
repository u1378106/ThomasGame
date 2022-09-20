using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

// attach to UI Text component (with the full text already there)

public class TypewriterText: MonoBehaviour
{

	TextMeshProUGUI txt;

	AudioManager audioManager;

	string story;

	void Awake()
	{ 
		txt = GetComponent<TextMeshProUGUI>();
		story = txt.text;
		txt.text = "";

		StartCoroutine("PlayText");
	}

    private void Start()
    {
		audioManager = FindObjectOfType<AudioManager>();
		audioManager.typewriterAudio.Play();
	}

    IEnumerator PlayText()
	{
		foreach (char c in story)
		{
			txt.text += c;
			yield return new WaitForSeconds(0.025f);
		}
		audioManager.typewriterAudio.Stop();	
	}

	public void StartGame()
    {
		audioManager.bgAudio.Play();
		this.transform.parent.gameObject.SetActive(false);
    }

}