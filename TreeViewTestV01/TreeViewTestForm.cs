using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TreeViewTestV01
{
	public partial class TreeViewTestForm : Form
	{

		public TreeViewTestForm()
		{
			InitializeComponent();
		}


		private static string filePath = @"C:\CSharpProjects\TestProjects\TreeView.bin";
		private void addSubjectButton_Click(object sender, EventArgs e)
		{
			treeView.Nodes.Add(nodeTextValue.Text);
		}

		private void addDivisionNodeButton_Click(object sender, EventArgs e)
		{
			treeView.SelectedNode.Nodes.Add(nodeTextValue.Text);
		}

		private void saveTreeButton_Click(object sender, EventArgs e)
		{
			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}
			// Create new array
			ArrayList al = new ArrayList();
			foreach (TreeNode tn in treeView.Nodes)
			{
				// back up every RootNode in the TreeView ...
				al.Add(tn);
			}

			// create file
			Stream file = File.Open(filePath, FileMode.Create);
			// Binary formatting init.
			BinaryFormatter bf = new BinaryFormatter();
			try
			{
				// Serializing the array
				bf.Serialize(file, al);
			}
			catch (System.Runtime.Serialization.SerializationException eex1)
			{
				MessageBox.Show("Serialization failed : {0}", eex1.Message);
			}

			// Close file
			file.Close();
		}

		private void loadTreeButton_Click(object sender, EventArgs e)
		{
			if (File.Exists(filePath))
			{
				// open file
				Stream file = File.Open(filePath, FileMode.Open);
				// Binary formatting init.
				BinaryFormatter bf = new BinaryFormatter();
				// Object var. init.
				object obj = null;
				try
				{
					// Deserialize data from the file
					obj = bf.Deserialize(file);
				}
				catch (System.Runtime.Serialization.SerializationException eex2)
				{
					MessageBox.Show("De-Serialization failed : {0}", eex2.Message);
				}
				// Close File
				file.Close();

				// Create a new array
				ArrayList nodeList = obj as ArrayList;

				// load Root-Nodes
				foreach (TreeNode node in nodeList)
				{
					treeView.Nodes.Add(node);
				}

			}
		}


		private IEnumerable<TreeNode> Collect(TreeNodeCollection nodes)
		{
			foreach (TreeNode node in nodes)
			{
				yield return node;

				foreach (var child in Collect(node.Nodes))
					yield return child;
			}
		}// End IEnumerable<TreeNode> Collect
		private void getNodeNamesButton_Click(object sender, EventArgs e)
		{

			foreach (var node in Collect(treeView.Nodes))
			{
				// you will see every child node here
				string nodesText = node.Text;
				MessageBox.Show($"The Name of this node in {nodesText}");
				if (nodesText == "D00")
				{
					treeView.LabelEdit = true;
					treeView.SelectedNode = node;
					node.Text = "X00";
				}
			}// End foreach

		}// End getNodeNamesButton_Click

		private void button1_Click(object sender, EventArgs e)
		{

			Dictionary<string, string> treeViewDictionary = new Dictionary<string, string>();
			Dictionary<string, string> inverseTreeViewDictionary = new Dictionary<string, string>();

			string[] treeViewDictionaryStrings = File.ReadAllLines(@"C:\CSharpProjects\TestProjects\TreeViewDictionary.txt");
			SortedDictionary<string, string> sortedTreeViewDictionary = new SortedDictionary<string, string>();
			foreach (string line in treeViewDictionaryStrings)
			{
				string key = line.Substring(0, line.IndexOf('^'));
				string value = line.Substring(line.IndexOf('^') + 1);
				sortedTreeViewDictionary.Add(key, value);
			}

			foreach (KeyValuePair<string, string> kvp in sortedTreeViewDictionary)
			{
				//string thisLine = $"key = {kvp.Key} and value = {kvp.Value}";
				treeViewDictionary.Add(kvp.Key, kvp.Value);
				inverseTreeViewDictionary.Add(kvp.Value, kvp.Key);
			}
			treeView.BeginUpdate();
			foreach (KeyValuePair<string,string> kvp in treeViewDictionary)
			{
				string nodeName = kvp.Key;
				string nodeText = kvp.Value;
				string[] nodeNameComponents = nodeName.Split('.');
				string parentsName = "";
				//for (int i=0; i< nodeNameComponents.Length-1; i++)
				//{
				//	parentsName = parentsName + nodeNameComponents[i] + '.';
				//}
				//if(parentsName.Length != 0)
				//{
				//	parentsName = parentsName.Substring(0, parentsName.Length - 1);
				//}				
				int numDots = nodeNameComponents.Length;
				TreeNode thisNode = new TreeNode();
				switch (numDots)
				{
					case 1:
						treeView.Nodes.Add(nodeText);
						int thisNodesNumber0 = Int32.Parse(nodeNameComponents[0]);
						thisNode = treeView.Nodes[thisNodesNumber0];
						thisNode.Name = nodeName;
						break;
					case 2:
						int node0 = Int32.Parse(nodeNameComponents[0]);
						treeView.Nodes[node0].Nodes.Add(nodeText);
						thisNodesNumber0 = Int32.Parse(nodeNameComponents[0]);
						int thisNodesNumber1 = -1;
						if (nodeNameComponents[1].IndexOf('q') != -1)
						{

							TreeNode selectedNode = treeView.Nodes[thisNodesNumber0];
							thisNodesNumber1 = selectedNode.GetNodeCount(true);

						}
						else
						{
							thisNodesNumber1 = Int32.Parse(nodeNameComponents[1]);
						}
						thisNode = treeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1];
						thisNode.Name = nodeName;
						break;
					case 3:
						//node0 = Int32.Parse(nodeNameComponents[0]);
						thisNodesNumber0 = Int32.Parse(nodeNameComponents[0]);
						thisNodesNumber1 = Int32.Parse(nodeNameComponents[1]);
						int thisNodesNumber2 = -1;
						if (nodeNameComponents[2].IndexOf('q') != -1)
						{

							TreeNode selectedNode = treeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1];
							thisNodesNumber2 = selectedNode.GetNodeCount(true);

						}
						else
						{
							thisNodesNumber2 = Int32.Parse(nodeNameComponents[2]);
						}
						treeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes.Add(nodeText);
						thisNode = treeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2];
						thisNode.Name = nodeName;
						break;
					case 4:
						thisNodesNumber0 = Int32.Parse(nodeNameComponents[0]);
						thisNodesNumber1 = Int32.Parse(nodeNameComponents[1]);
						thisNodesNumber2 = Int32.Parse(nodeNameComponents[2]);
						int thisNodesNumber3 = -1;
						if (nodeNameComponents[3].IndexOf('q') != -1)
						{

							TreeNode selectedNode = treeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2];
							thisNodesNumber3 = selectedNode.GetNodeCount(true);

						}
						else
						{
							thisNodesNumber3 = Int32.Parse(nodeNameComponents[3]);
						}

						treeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes.Add(nodeText);
						thisNode = treeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3];
						thisNode.Name = nodeName;
						break;

					case 5:
						thisNodesNumber0 = Int32.Parse(nodeNameComponents[0]);
						thisNodesNumber1 = Int32.Parse(nodeNameComponents[1]);
						thisNodesNumber2 = Int32.Parse(nodeNameComponents[2]);
						thisNodesNumber3 = Int32.Parse(nodeNameComponents[3]);
						int thisNodesNumber4 = -1;
						if (nodeNameComponents[4].IndexOf('q') != -1)
						{

							TreeNode selectedNode = treeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3];
							thisNodesNumber4 = selectedNode.GetNodeCount(true);

						}
						else
						{
							thisNodesNumber4 = Int32.Parse(nodeNameComponents[4]);
						}

						treeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3].Nodes.Add(nodeText);
						thisNode = treeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3];
						thisNode.Name = nodeName;
						break;
					case 6:
						thisNodesNumber0 = Int32.Parse(nodeNameComponents[0]);
						thisNodesNumber1 = Int32.Parse(nodeNameComponents[1]);
						thisNodesNumber2 = Int32.Parse(nodeNameComponents[2]);
						thisNodesNumber3 = Int32.Parse(nodeNameComponents[3]);
						thisNodesNumber4 = Int32.Parse(nodeNameComponents[4]);
						int thisNodesNumber5 = -1;
						if (nodeNameComponents[5].IndexOf('q') != -1)
						{
							
							TreeNode selectedNode = treeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3].Nodes[thisNodesNumber4];
							thisNodesNumber5 = selectedNode.GetNodeCount(true);

						}
						else
						{
							thisNodesNumber5 = Int32.Parse(nodeNameComponents[5]);
						}						
						treeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3].Nodes[thisNodesNumber4].Nodes.Add(nodeText);
						thisNode = treeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3].Nodes[thisNodesNumber4].Nodes[thisNodesNumber5];
						thisNode.Name = nodeName;
						break;
					case 7:
						thisNodesNumber0 = Int32.Parse(nodeNameComponents[0]);
						thisNodesNumber1 = Int32.Parse(nodeNameComponents[1]);
						thisNodesNumber2 = Int32.Parse(nodeNameComponents[2]);
						thisNodesNumber3 = Int32.Parse(nodeNameComponents[3]);
						thisNodesNumber4 = Int32.Parse(nodeNameComponents[4]);
						thisNodesNumber5 = Int32.Parse(nodeNameComponents[5]);
						int thisNodesNumber6 = Int32.Parse(nodeNameComponents[6]);
						treeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3].Nodes[thisNodesNumber4].Nodes[thisNodesNumber5].Nodes.Add(nodeText);
						thisNode = treeView.Nodes[thisNodesNumber0].Nodes[thisNodesNumber1].Nodes[thisNodesNumber2].Nodes[thisNodesNumber3].Nodes[thisNodesNumber4].Nodes[thisNodesNumber5].Nodes[thisNodesNumber6];
						thisNode.Name = nodeName;
						break;
					case 8:

						break;
					case 9:

						break;
					case 10:

						break;
					case 11:

						break;


				}

			}
			treeView.EndUpdate();
			// Create a string[] arrayOfLines[treeViewDictionary.Count] to hold an
			// a '^' delimited string of nodeText, nodeName,  parent'sNodeText
			//	    string[3] arrayOfNodeValues where [0] = nodeText, [1] = nodeName, and [3] parent'sNodeText
			//string[] arrayOfLines = new string[treeViewDictionary.Count];
			//string delimitedNodeValues = "";
			//int arrayOfLinesCntr = 0;
			//foreach (KeyValuePair<string, string> kvp in treeViewDictionary)
			//{
			//	string nodeName = kvp.Key;
			//	string nodeText = kvp.Value;
			//	if (nodeName.IndexOf('.') == -1)
			//	{
			//		// This is a subjectNode
			//		delimitedNodeValues = nodeText + '^' + nodeName + '^' + "";					
			//	}
			//	else
			//	{
			//		// Get parent's nodeText from nodeName
			//		int posLastDot = nodeName.LastIndexOf('.');
			//		string parentsNodeName = nodeName.Substring(0, posLastDot);
			//		string parentsNodeText = treeViewDictionary[parentsNodeName];
			//		delimitedNodeValues = nodeText + '^' + nodeName + '^' + parentsNodeText;
			//	}
			//	arrayOfLines[arrayOfLinesCntr] = delimitedNodeValues;
			//	arrayOfLinesCntr++;
			//}

			// Populate the treeView from arrayOfLines
			//treeView = new TreeView();
			//treeView.BeginUpdate();
			//treeView = new TreeView();
			//for (int i=0; i< treeViewDictionary.Count; i++)
			//{
			//	TreeNodeCollection myNodeCollection = treeView.Nodes;
			//	string[] nodeComponents = arrayOfLines[i].Split('^');
			//	// Determine if this is a subject or a child node
			//	if (nodeComponents[2] == "")
			//	{
			//		// This is a subject node
			//		nodeTextValue.Text = nodeComponents[0];
			//		addSubjectButton.PerformClick();

			//		//TreeNode thisNode = new TreeNode();
			//		//thisNode.Text = nodeComponents[0];
			//		//thisNode.Name = nodeComponents[01];
			//		//treeView.Nodes.Add(thisNode);
			//		//bool index = treeView.Nodes.ContainsKey(nodeComponents[0]);

			//	}
			//	else
			//	{
			//		// This is a child node
			//		TreeNode thisNode = new TreeNode();
			//		thisNode.Text = nodeComponents[0];
			//		thisNode.Name = nodeComponents[1];
			//		string parentsText = nodeComponents[2];
			//		TreeNode parentNode = new TreeNode();
			//		parentNode.Text = parentsText;
			//		//int index = myNodeCollection.IndexOf(parentsText);
			//		treeView.SelectedNode = myNodeCollection.Find(parentsText, true)[0];
			//		nodeTextValue.Text = nodeComponents[0];
			//		addDivisionNodeButton.PerformClick();


			//	}
			//}
			//treeView.EndUpdate();


			//TreeNode node = new TreeNode();
			//// Display a wait cursor while the TreeNodes are being created.
			//Cursor.Current = new Cursor("MyWait.cur");

			//// Suppress repainting the TreeView until all the objects have been created.
			//treeView.BeginUpdate();
			//foreach (KeyValuePair<string,string> kvp in treeViewDictionary)
			//{
			//	string nodeName = kvp.Key;
			//	string nodeText = kvp.Value;
			//	if (nodeName.IndexOf('.') == -1)
			//	{
			//		// This is a subject node
			//		node.Text = nodeText;
			//		node.Name = nodeName;
			//		treeView.Nodes.Add(node);
			//	}
			//	else
			//	{
			//		// This is a divisional node
			//		int posLastDot = nodeName.LastIndexOf('.');
			//		string parent = nodeName.Substring(0, posLastDot);
			//		treeView.SelectedNode = treeView.Nodes[parent];

			//		node.Text = nodeText;
			//		node.Name = nodeName;
			//		//string parentText = inverseTreeViewDictionary[parent];
			//		treeView.SelectedNode.Nodes.Add(nodeText);
			//		treeView.SelectedNode = null;
			//	}
			//}
			//// Reset the cursor to the default for all controls.
			//Cursor.Current = Cursors.Default;

			// Begin repainting the TreeView.
			//treeView.EndUpdate();
		}



		//}

		private void TreeViewTestForm_Load(object sender, EventArgs e)
		{

		}
	}// End TreeViewTestForm Class
}// End namespace GTreeViewTest01
