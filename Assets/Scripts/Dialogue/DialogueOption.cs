using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace DialogueTree
{
    public class DialogueOption
    {
        public string text;
        public int destinationNodeID;

        //parameterless constructor for serialization.
        public DialogueOption() { }

        public DialogueOption(string incomingText, int dest)
        {
            this.text = incomingText;
            this.destinationNodeID = dest;
        }

    }
}
