using CTCI.Lib;
using CTCI.Lib.DataStructure;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CTCI.Test
{
	public class TreeOperationsTest
    {
		[Fact]
		public void Test_BFS()
		{
			TreeNode root = new TreeNode(1);
			root.AddLeaf(2);
			root.AddLeaf(3);
			root.Leafs.ElementAt(0).AddLeaf(4);
			root.Leafs.ElementAt(0).AddLeaf(5);
			root.Leafs.ElementAt(0).Leafs.ElementAt(0).AddLeaf(7);
			root.Leafs.ElementAt(1).AddLeaf(6);

			List<int> result = TreeOperations.BreadthFirstTraversal(root);

			result.ElementAt(0).ShouldBe(1);
			result.ElementAt(1).ShouldBe(2);
			result.ElementAt(2).ShouldBe(3);
			result.ElementAt(3).ShouldBe(4);
			result.ElementAt(4).ShouldBe(5);
			result.ElementAt(5).ShouldBe(6);
			result.ElementAt(6).ShouldBe(7);
		}

		[Fact]
		public void Test_DFS()
		{
			TreeNode root = new TreeNode(1);
			root.AddLeaf(2);
			root.AddLeaf(3);
			root.Leafs.ElementAt(0).AddLeaf(4);
			root.Leafs.ElementAt(0).AddLeaf(5);
			root.Leafs.ElementAt(0).Leafs.ElementAt(0).AddLeaf(7);
			root.Leafs.ElementAt(1).AddLeaf(6);

			List<int> result = TreeOperations.DepthFirstTraversal(root);

			result.ElementAt(0).ShouldBe(1);
			result.ElementAt(1).ShouldBe(2);
			result.ElementAt(2).ShouldBe(4);
			result.ElementAt(3).ShouldBe(7);
			result.ElementAt(4).ShouldBe(5);
			result.ElementAt(5).ShouldBe(3);
			result.ElementAt(6).ShouldBe(6);
		}
	}
}
