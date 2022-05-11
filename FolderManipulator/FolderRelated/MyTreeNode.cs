using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.FolderRelated
{
    class MyTreeNode : IEnumerable<MyTreeNode>
    {
        private readonly Dictionary<string, MyTreeNode> _children =
                                            new Dictionary<string, MyTreeNode>();

        public readonly string ID;
        public MyTreeNode Parent { get; private set; }

        public MyTreeNode(string id)
        {
            this.ID = id;
        }

        public MyTreeNode GetChild(string id)
        {
            return this._children[id];
        }

        public void Add(MyTreeNode item)
        {
            if (item.Parent != null)
            {
                item.Parent._children.Remove(item.ID);
            }

            item.Parent = this;
            this._children.Add(item.ID, item);
        }

        public IEnumerator<MyTreeNode> GetEnumerator()
        {
            return this._children.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int Count
        {
            get { return this._children.Count; }
        }
    }
}
