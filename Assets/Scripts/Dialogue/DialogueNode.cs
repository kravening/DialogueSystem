using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DialogueTree
{
    public class DialogueNode
    {
        public int nodeID = -1;

        public string text;

        public List<DialogueOption> options;

        //parameterless constructor for serialization.
        public DialogueNode()
        {
            options = new List<DialogueOption>();
        }

        public DialogueNode(string incomingText)
        {
            text = incomingText;
            options = new List<DialogueOption>();
        }
    }
}