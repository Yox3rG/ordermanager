﻿using FolderManipulator.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderManipulator.UI
{
    public class TreeViewHandle
    {
        private List<Guid> checkedData;
        private int scrollBarValue;

        public TreeView TreeView { get; private set; }
        public TreeViewEventHandler AfterCheckFunction { get; private set; }


        public TreeViewHandle(TreeView treeView, TreeViewEventHandler afterCheckFunction, List<Guid> checkedData)
        {
            TreeView = treeView;
            AfterCheckFunction = afterCheckFunction;
            this.checkedData = checkedData;
            this.scrollBarValue = 0;
        }

        public void UpdateCheckedData(List<Guid> newCheckedData)
        {
            checkedData = newCheckedData;
        }

        public List<Guid> GetCheckedData()
        {
            return checkedData;
        }

        public void ClearCheckedData()
        {
            checkedData.Clear();
        }

        public void AddAfterCheckFunction()
        {
            TreeView.AfterCheck += AfterCheckFunction;
        }

        public void RemoveAfterCheckFunction()
        {
            TreeView.AfterCheck -= AfterCheckFunction;
        }

        public void SaveCurrentScrollBarPosition()
        {
            scrollBarValue = TreeView.GetTreeViewScrollPosVertical();
        }

        public void ResetToSavedScrollBarPosition()
        {
            TreeView.SetTreeViewScrollPosVertical(scrollBarValue);
        }
    }
}
