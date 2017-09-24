using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DialogueTree
{
    public class Dialogue
    {
        public List<DialogueNode> nodes;
        public void AddNode(DialogueNode node)
        {
            //if the dialogue node is null it's an exit so we can skip adding it
            if(node == null) { return; }
            //add the node to the dialogue list of nodes
            nodes.Add(node);
            //give the node an id
            node.nodeID = nodes.IndexOf(node);

        }

        public void AddOption(string text, DialogueNode node, DialogueNode dest)
        {
            //assign a destination to the node if there is none
            if (!nodes.Contains(dest))
                AddNode(dest);
            //assign a node to the node if there is none
            if (!nodes.Contains(node))
                AddNode(node);

            DialogueOption opt;

            if (dest == null)
                opt = new DialogueOption(text, -1);
            else
                opt = new DialogueOption(text, dest.nodeID);

            node.options.Add(opt);

        }

        public Dialogue()
        {
            nodes = new List<DialogueNode>();
        }
    }
}
