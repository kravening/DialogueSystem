using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

namespace DialogueTree
{
    public class DialogueCreator : MonoBehaviour
    {
        void Start()
        {
            CreateDialogue();
        }

        private static void CreateDialogue()
        {
            Dialogue dia = new Dialogue();

            DialogueNode node1 = new DialogueNode(incomingText: "Good evening.");
            DialogueNode node2 = new DialogueNode(incomingText: "Could i have a Gut Punch");
            DialogueNode node3 = new DialogueNode(incomingText: "Oh... didn't know what to expect, but the name is a fitting description for this HEALTHY NON ALCOHOLIC beverage");
            DialogueNode node4 = new DialogueNode(incomingText: "Are you sure this is a gut punch?");
            dia.AddNode(node1);
            dia.AddNode(node2);
            dia.AddNode(node3);
            dia.AddNode(node4);

            dia.AddOption("Ayy waddup boi", node1, node2);
            dia.AddOption("Coming right up (make Gut Punch)", node2, node3);
            dia.AddOption("Coming right up (make something else)", node2, node4);
            dia.AddOption("Right?, actually interesting fact. it used to be customary for the bartender to punch you in the gut while you down it, but after a certain accident we stopped doing it.", node3, null);
            dia.AddOption("oops", node4, null);

            XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
            StreamWriter writer = new StreamWriter("Assets\\dialogue.xml");

            serz.Serialize(writer, dia);
            writer.Close();
        }

    }
}
