using System.Windows.Forms;

namespace Big6Search.ScriptingEngine
{
    public class ScriptTreeNode : TreeNode
    {

        #region Public Properties
        #region RunTimeItem - Returns the RunTimeObject that is associated with the tree node.
        /// <summary>
    /// Returns the RunTimeObject that is associated with the tree node.
    /// </summary>
    /// <remarks></remarks>
        public readonly RunTime.RunTimeObject RunTimeItem;
        #endregion
        #endregion

        #region Public Constructors
        #region New - Creates a new ScriptTreeNode.
        /// <summary>
    /// Creates a new ScriptTreeNode with an associated RunTimeObject with specific text.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="text"></param>
    /// <remarks></remarks>
        public ScriptTreeNode(RunTime.RunTimeObject item, string text) : this(item, text, null)
        {
        }
        /// <summary>
    /// Creates a new ScriptTreeNode for a block of commands with no associated RunTimeObject using the default node text [Command Block].
    /// </summary>
    /// <param name="commands"></param>
    /// <remarks></remarks>
        public ScriptTreeNode(RunTime.Command[] commands) : this("[Command Block]", commands)
        {
        }
        /// <summary>
    /// Creates a new ScriptTreeNode for a block of commands with no associated RunTimeObject with specific node text.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="commands"></param>
    /// <remarks></remarks>
        // This block does not have a single runtime item tied to it.
        public ScriptTreeNode(string text, RunTime.Command[] commands) : this(null, text, null)
        {

            // Now create tree nodes from each command and add them to the tree as children.
            if (!(commands == null))
            {
                foreach (RunTime.Command command in commands)
                    Nodes.Add(command.ToTreeNode());
            }
        }
        /// <summary>
    /// Creates a new ScriptTreeNode with an associated RunTimeObject with specific text and optional children ScripTreeNode.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="text"></param>
    /// <param name="children"></param>
    /// <remarks></remarks>
        public ScriptTreeNode(RunTime.RunTimeObject item, string text, params ScriptTreeNode[] children) : base(text)
        {
            RunTimeItem = item;
            if (!(children == null))
            {
                Nodes.AddRange(children);
            }
        }
        #endregion
        #endregion

    }
}