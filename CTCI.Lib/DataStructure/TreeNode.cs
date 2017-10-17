using System.Collections.Generic;

namespace CTCI.Lib.DataStructure
{
	public class TreeNode
	{
		public int Data { get; set; }
		public List<TreeNode> Leafs { get; }

		public TreeNode(int data)
		{
			Leafs = new List<TreeNode>();
			Data = data;
		}

		public void AddLeaf(int data)
		{
			Leafs.Add(new TreeNode(data));
		}
	}
}
