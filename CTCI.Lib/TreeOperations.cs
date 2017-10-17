using CTCI.Lib.DataStructure;
using System.Collections.Generic;

namespace CTCI.Lib
{
	public static class TreeOperations
    {
		public static List<int> BreadthFirstTraversal(TreeNode root)
		{
			List<int> treeData = new List<int>();
			Queue<TreeNode> nodesToProcess = new Queue<TreeNode>();
			nodesToProcess.Enqueue(root);

			while(nodesToProcess.Count > 0)
			{
				TreeNode currentNode = nodesToProcess.Dequeue();
				treeData.Add(currentNode.Data);

				foreach (TreeNode leaf in currentNode.Leafs)
					nodesToProcess.Enqueue(leaf);
			}

			return treeData;
		}

		public static List<int> DepthFirstTraversal(TreeNode root)
		{
			List<int> treeData = new List<int>();
			Stack<TreeNode> nodesToProcess = new Stack<TreeNode>();
			nodesToProcess.Push(root);

			while (nodesToProcess.Count > 0)
			{
				TreeNode currentNode = nodesToProcess.Pop();
				treeData.Add(currentNode.Data);

				currentNode.Leafs.Reverse();

				foreach (TreeNode leaf in currentNode.Leafs)
					nodesToProcess.Push(leaf);
			}

			return treeData;
		}
	}
}
