using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderManipulator.FolderRelated
{
    class FolderStructure
    {
        private MyTreeNode root;
        private string sourcePath;

        public bool IsValid { get { return root != null; } }

        public FolderStructure(string sourcePath)
        {
            this.sourcePath = sourcePath;
            if (!System.IO.Directory.Exists(sourcePath))
            {
                root = null;
            }
            else
            {
                root = new MyTreeNode(sourcePath);
                BuildTreeRecursive(root);
            }
        }

        public bool FillTreeView(TreeView tv)
        {
            tv.BeginUpdate();

            tv.Nodes.Clear();
            tv.Nodes.Add(root.ID);

            FillNodeRecursive(tv.Nodes[0].Nodes, root);

            tv.EndUpdate();
            return true;
        }

        private void FillNodeRecursive(TreeNodeCollection currentTreeNode, MyTreeNode currentNode)
        {
            var enumerator = currentNode.GetEnumerator();

            int i = 0;
            while (enumerator.MoveNext())
            {
                currentTreeNode.Add(enumerator.Current.ID);
                FillNodeRecursive(currentTreeNode[i].Nodes, enumerator.Current);
                i++;
            }
        }

        private void BuildTreeRecursive(MyTreeNode current)
        {
            CreateChildrenFromStrings(parent: current, LoadFolderNames(current.ID));

            var enumerator = current.GetEnumerator();
            while (enumerator.MoveNext())
            {
                BuildTreeRecursive(enumerator.Current);
            }
        }

        private void CreateChildrenFromStrings(MyTreeNode parent, string[] elements)
        {
            foreach (string s in elements)
            {
                parent.Add(new MyTreeNode(s));
            }
        }

        public static string[] LoadFolderNames(string path)
        {
            return System.IO.Directory.GetDirectories(path);
        }
    }
}
