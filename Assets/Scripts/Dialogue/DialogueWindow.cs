using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DialogueTree;

public class DialogueWindow : MonoBehaviour {
    Dialogue dia;

    GameObject dialogueWindow;
    GameObject nodeText;
    GameObject option_1;
    GameObject option_2;
    GameObject option_3;
    GameObject exit;

    int selectedOption = -2;

    string dialogueDataFilePath;

    GameObject dialogueWindowPrefab;

	// Use this for initialization
	void Start () {
        dia = Dialogue.LoadDialogue("assets/" + dialogueDataFilePath);

        var canvas = GameObject.Find("canvas"); //huh

        dialogueWindow = Instantiate<GameObject>(dialogueWindowPrefab);

        dialogueWindow.transform.parent = canvas.transform;
        RectTransform diaWindowTransform = (RectTransform)dialogueWindow.transform; //order??

        diaWindowTransform.localPosition = new Vector3(0, 0, 0);

        //replace inline name strings with static variables from a database of names / tags.
        nodeText = GameObject.Find("text_DiaNodeText");
        option_1 = GameObject.Find("Button_Option1");
        option_2 = GameObject.Find("Button_Option2");
        option_3 = GameObject.Find("Button_Option3");
        exit = GameObject.Find("Button_End");

        exit.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOption(-1); });

        dialogueWindow.SetActive(false);

        RunDialogue();
    }

    public void RunDialogue()
    {
        StartCoroutine(Run());
    }

    public void SetSelectedOption(int x)
    {
        selectedOption = x;
    }

    public IEnumerator Run()
    {
        dialogueWindow.SetActive(true);

        //Create a node indexer,and initialize it to the start node.
        int nodeID = 0;

        //if the next node is not an exit node, traverse the dialogue tree based on the user input.
        while (nodeID != -1)
        {

            while (selectedOption == -2)
            {
                yield return new WaitForSeconds(0.25f);
            }
        }
    }
    private void DisplayNode(DialogueNode node)
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public string DialogueDataFilePath
    {
        get {  return dialogueDataFilePath; }
        set { dialogueDataFilePath = value; }
    }

    public GameObject DialogueWindowPrefab
    {
        get {  return dialogueWindowPrefab; }
        set { dialogueWindowPrefab = value; }
    }
}
