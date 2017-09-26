using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DialogueTree;

public class DialogueWindow : MonoBehaviour {
    public Dialogue dia;

    public GameObject dialogueWindow;
    public GameObject nodeText;
    public GameObject option_1;
    public GameObject option_2;
    public GameObject option_3;
    public GameObject exit;

    public int selectedOption = -2;

    public string dialogueDataFilePath;

    public GameObject dialogueWindowPrefab;

	// Use this for initialization
	void Start () {
        dia = Dialogue.LoadDialogue(dialogueDataFilePath);
        Debug.Log(dia);

        var canvas = GameObject.Find("Canvas");

        dialogueWindow = Instantiate<GameObject>(dialogueWindowPrefab);

        RectTransform diaWindowTransform = (RectTransform)dialogueWindow.transform; //order??
        dialogueWindow.transform.parent = canvas.transform;

        diaWindowTransform.localPosition = new Vector3(0, 0, 0);

        //replace inline name strings with static variables from a database of names / tags.
        nodeText = GameObject.Find("Text_DiaNodeText");
        option_1 = GameObject.Find("Button_Option1");
        option_2 = GameObject.Find("Button_Option2");
        option_3 = GameObject.Find("Button_Option3");
        exit = GameObject.Find("Button_End");

        exit.GetComponent<Button>().onClick.AddListener(() => SetSelectedOption(-1));

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
            DisplayNode(dia.nodes[nodeID]);
            selectedOption = -2;
            while (selectedOption == -2)
            {
                yield return new WaitForSeconds(0.25f);
            }

            nodeID = selectedOption;
        }
        dialogueWindow.SetActive(false);
    }
    private void DisplayNode(DialogueNode node)
    {
        Debug.Log("uhhu");
        nodeText.GetComponent<Text>().text = node.text;

        option_1.SetActive(false);
        option_2.SetActive(false);
        option_3.SetActive(false);

        for (int i = 0; i < node.options.Count; i++)
        {
            switch (i)
            {
                case 0:
                    SetOptionButton(option_1, node.options[i]);
                    break;
                case 1:
                    SetOptionButton(option_2, node.options[i]);
                    break;
                case 2:
                    SetOptionButton(option_3, node.options[i]);
                    break;
            }
        }
    }

    private void SetOptionButton(GameObject button, DialogueOption option)
    {
        button.SetActive(true);
        Debug.Log(option);
        button.GetComponentInChildren<Text>().text = option.text;
        button.GetComponent<Button>().onClick.AddListener(() => SetSelectedOption(option.destinationNodeID));
    }
}
