using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {

	public static DialogueSystem Instance {get; set;}

	public GameObject dialoguePanel;

	private NavMeshAgent playerAgent;

	[HideInInspector]
	public string npcName;

	[HideInInspector]
	public List<string> dialogueLines = new List<string> ();


	Button continueButton;

	Text dialogueText, nameText;

	int dialogueIndex;




	void Start () {

		playerAgent = GameObject.FindWithTag ("Player").GetComponent<WorldInteraction> ().PlayerAgent;

		continueButton = dialoguePanel.transform.FindChild ("ContinueButton").GetComponent<Button> ();

		dialogueText = dialoguePanel.transform.FindChild ("Text").GetComponent<Text> ();

		nameText = dialoguePanel.transform.FindChild ("Name").GetChild (0).GetComponent<Text> ();

		continueButton.onClick.AddListener (delegate { ContinueDialogue(); });

		dialoguePanel.SetActive (false);

		if (Instance != null && Instance != this) {

			Destroy (gameObject);

		} else {

			Instance = this;
		}

	}

	void Update () {

	}
		
	public void AddNewDialogue(string[] lines, string npcName) {

		dialogueIndex = 0;

		dialogueLines = new List<string> ();

		foreach (string line in lines) {

			dialogueLines.Add (line);
		}

		this.npcName = npcName;

		//Debug.Log (dialogueLines.Count);

		CreateDialogue ();

	}

	public void CreateDialogue(){

		dialogueText.text = dialogueLines [0];

		nameText.text = npcName;

		dialoguePanel.SetActive (true);

	}

	public void ContinueDialogue(){

		if (dialogueIndex < dialogueLines.Count - 1) {

			dialogueIndex++;

			dialogueText.text = dialogueLines [dialogueIndex];

		} else {

			dialoguePanel.SetActive (false);
		}

	}

}
