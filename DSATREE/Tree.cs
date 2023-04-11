using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DSATREE;


class TreeNode
{
	public int val;
	public TreeNode left, right;

	public TreeNode(int item)
	{
		val = item;
		left = right = null;
	}
}

class BinaryTree
{

	TreeNode root;

	BinaryTree() { root = null; }


	void printPostorder(TreeNode node)
	{
		if (node == null)
		{
			return;
		}

		printPostorder(node.left);
		printPostorder(node.right);
		Console.Write(node.val + " ");

	}
	void printInPostPreorder(TreeNode node) {

		Stack<Tuple<TreeNode, int>> ss = new Stack<Tuple<TreeNode, int>>();
		ss.Push(new Tuple<TreeNode, int>(node, 1));

		List<int> Preorder = new List<int>();
		List<int> Inorder = new List<int>();
		List<int> Postorder = new List<int>();

		while (ss.Any())
	      {
	          Tuple<TreeNode,int> it = ss.Pop();

	          if (it.Item2 == 1)
	          {
				Tuple<TreeNode, int> temp = ss.Peek();

				temp = new Tuple<TreeNode,int>(temp.Item1, temp.Item2 + 1);

				ss.Pop();
				ss.Push(temp);



			}
	      }


	}

	int MaxDepth(TreeNode node)
	{
		if (node == null)
		{
			return 0;
		}

		int left = MaxDepth(node.left);
		int right = MaxDepth(node.right);

		return 1 + Math.Max(left, right);

	}

	bool IsSameTree(TreeNode p, TreeNode q)
	{

		if (p == null || q == null)
		{

			if (p == null && q == null)
			{

				return true;
			}
			else
			{
				return false;
			}

		}

		if (p.val == q.val)
		{

			bool left = IsSameTree(p.left, q.left);
			bool right = IsSameTree(p.right, q.right);

			if (left == true && right == true)
			{

				return true;
			}
			else
			{
				return false;
			}

		}

		return false;
	}

	int diameteroftree(TreeNode node)
	{
		int[] diameter = new int[1];
		Dfsheightdiameter(node, diameter);
		return diameter[0];
	}

	int Dfsheightdiameter(TreeNode node, int[] diameter)
	{

		if (node == null)
		{
			return 0;
		}

		int left = Dfsheightdiameter(node.left, diameter);
		int right = Dfsheightdiameter(node.right, diameter);

		diameter[0] = Math.Max(diameter[0], left + right);


		return 1 + Math.Max(left, right);
	}

	bool isbalanced(TreeNode node)
	{
		return dfsheight(node) != -1;
	}

	int dfsheight(TreeNode node) {

		if (node == null)
		{
			return 0;
		}

		int Left = dfsheight(node.left);

		if (Left == -1)
		{
			return -1;
		}

		int right = dfsheight(node.right);


		if (right == -1)
		{
			return -1;
		}

		if (Math.Abs(Left - right) > 1)
		{
			return -1;
		}

		return Math.Max(Left, right) + 1;

	}


	int MinDepth(TreeNode node)
	{
		if (node == null)
		{
			return 0;
		}

		int left = MinDepth(node.left);
		int right = MinDepth(node.right);

		if (left == null || right == null) {
			return 1 + Math.Max(left, right);
		}

		return 1 + Math.Min(left, right);

	}



	void printInorder(TreeNode node)
	{
		if (node == null)
		{
			return;
		}

		printInorder(node.left);
		Console.Write(node.val + " ");
		printInorder(node.right);
	}


	void printPreorder(TreeNode node)
	{
		if (node == null) {
			return;
		}
		Console.Write(node.val + " ");
		printPreorder(node.left);
		printPreorder(node.right);

	}

	void IterativeprintInorder(TreeNode node) {


		Stack<TreeNode> ss = new Stack<TreeNode>();
		List<int> ls = new List<int>();


		while (true)
		{
			if (root != null)
			{
				ss.Push(root);
				root = root.left;
			}
			else
			{
				if (ss.Count == 0)
				{
					break;
				}

				root = ss.Pop();
				ls.Add(root.val);
				root = root.right;
			}

		}
		foreach (var b in ls)
		{
			Console.Write(b + " ");
		}


	}



	void IterativeprintPreorder(TreeNode node) {

		Stack<TreeNode> ss = new Stack<TreeNode>();

		List<int> Preorder = new List<int>();

		ss.Push(node);

		while (ss.Any()) {

			var ans = ss.Pop();

			Preorder.Add(ans.val);

			if (ans.right != null)
			{
				ss.Push(ans.right);
			}

			if (ans.left != null)
			{
				ss.Push(ans.left);
			}
		}

		foreach (var b in Preorder)
		{
			Console.Write(b + " ");
		}


	}

	void IterativeprintPostorder(TreeNode node) {

		Stack<TreeNode> stack1 = new Stack<TreeNode>();
		Stack<TreeNode> stack2 = new Stack<TreeNode>();
		List<int> ls = new List<int>();

		stack1.Push(node);

		while (stack1.Count != 0)
		{
			node = stack1.Pop();
			stack2.Push(node);

			if (node.left != null)
			{
				stack1.Push(node.left);
			}
			if (node.right != null)
			{
				stack1.Push(node.right);
			}
		}
		while (stack2.Count != 0)
		{
			ls.Add(stack2.Pop().val);
		}


		foreach (var s in ls)
		{
			Console.Write(s + " ");
		}

	}




	public IList<IList<int>> LevelOrder(TreeNode node)
	{
		Queue<TreeNode> qs = new Queue<TreeNode>();

		List<IList<int>> ls = new List<IList<int>>();

		qs.Enqueue(root);

		while (qs.Any())
		{
			int size = qs.Count();
			var oneResult = new List<int>();

			for (int i = 0; i < size; i++)
			{
				var curr = qs.Dequeue();

				oneResult.Add(curr.val);
				if (curr.left != null)
				{
					qs.Enqueue(curr.left);
				}

				if (curr.right != null)
				{
					qs.Enqueue(curr.right);
				}

			}
			ls.Add(oneResult);
		}
		return ls;
	}

	public IList<IList<int>> Zigzaglevelorder(TreeNode node)
	{

		Queue<TreeNode> qs = new Queue<TreeNode>();

		List<IList<int>> ls = new List<IList<int>>();
		if (root == null)
			return ls;

		int rowNum = 0;

		qs.Enqueue(root);

		while (qs.Any())
		{
			int size = qs.Count();
			var oneResult = new List<int>();

			for (int i = 0; i < size; i++)
			{
				var curr = qs.Dequeue();

				oneResult.Add(curr.val);
				if (curr.left != null)
				{
					qs.Enqueue(curr.left);
				}

				if (curr.right != null)
				{
					qs.Enqueue(curr.right);
				}

			}

			if (rowNum % 2 == 1)
			{
				oneResult.Reverse();
			}

			ls.Add(oneResult);

			rowNum++;

		}
		return ls;
	}


	public IList<int> RightSideView(TreeNode root)
	{
		List<int> res = new List<int>();
		RightSide(root, 0, res);
		return res;

	}

	public void RightSide(TreeNode root, int depth, List<int> res)
	{
		if (root == null)
		{
			return;
		}

		if (depth == res.Count())
		{
			res.Add(root.val);
		}

		RightSide(root.right, depth + 1, res);
		RightSide(root.left, depth + 1, res);
	}

	private int Start = 0;
	public TreeNode BuildTree(int[] preorder, int[] inorder)
	{
		return recursion(preorder, inorder, 0, preorder.Length - 1);
	}
	private TreeNode recursion(int[] preorder, int[] inorder, int left, int right)
	{
		if (Start == preorder.Length || left > right)
		{
			return null;
		}
		TreeNode root = new TreeNode(preorder[Start]);
		for (int i = left; i <= right; i++)
		{
			if (preorder[Start] == inorder[i])
			{
				Start++;
				root.left = recursion(preorder, inorder, left, i - 1);
				root.right = recursion(preorder, inorder, i + 1, right);
				break;
			}
		}
		return root;
	}






	void printPostorder() { printPostorder(root); }
	void printInorder() { printInorder(root); }
	void printPreorder() { printPreorder(root); }
	void IterativeprintPreorder() { IterativeprintPreorder(root); }
	void IterativeprintInorder() { IterativeprintInorder(root); }
	void IterativeprintPostorder() { IterativeprintPostorder(root); }



	static public void Main(String[] args)
	{
		BinaryTree tree = new BinaryTree();
		tree.root = new TreeNode(1);
		tree.root.left = new TreeNode(2);
		tree.root.right = new TreeNode(3);
		tree.root.left.left = new TreeNode(4);
		tree.root.left.right = new TreeNode(5);
		Console.Write(tree.IsSameTree(tree.root,tree.root));
		Console.Write(tree.diameteroftree);
		Console.WriteLine(tree.isbalanced(tree.root));
		Console.WriteLine(tree.MinDepth(tree.root));
		tree.IterativeprintPostorder();
		     tree.IterativeprintInorder();

		Console.WriteLine(tree.MaxDepth(tree.root));

		int[] preorder = { 3, 9, 20, 15, 7 };
		int[] inorder = { 9, 3, 15, 20, 7 };

		var result = tree.BuildTree(preorder, inorder);

        var res = tree.RightSideView(tree.root);

		Console.WriteLine(result);

        var list = tree.Zigzaglevelorder(tree.root);

        foreach (var list2 in list)
        {
            foreach (var element in list2)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine();
        }
        Console.WriteLine("Preorder traversal "
                             + "of binary tree is ");
        tree.printPreorder();

        Console.WriteLine("Iterative Preorder traversal "
                            + "of binary tree is "); tree.IterativeprintPreorder();

        Console.WriteLine("\nInorder traversal "
                       + "of binary tree is ");
        tree.printInorder();

        Console.WriteLine("\nPostorder traversal "
                       + "of binary tree is ");
        tree.printPostorder();





    }
}

