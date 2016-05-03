using UnityEngine;
using System.Collections.Generic;

public class WorldGrid : MonoBehaviour {
	
	[SerializeField]
	private int xSize,ySize,zSize;
	private  Dictionary<Vector3, GridBlock> grid;

	void Start()
	{
		grid = new Dictionary<Vector3, GridBlock>();
		InitializeWorldGrid();
	}
	
	private void InitializeWorldGrid()
	{
		//0,0,0 is the center
		for(int k = (int)(Math.Abs(zSize)/-2); k < (int)(Math.Abs(zSize)/2); k++)
		{
			for(int j = (int)(Math.Abs(ySize)/-2); j < (int)(Math.Abs(ySize)/2); j++)
			{
				for(int i = (int)(Math.Abs(xSize)/-2); i < (int)(Math.Abs(xSize)/2); i++)
				{
					grid.Add(new Vector3(i,j,k), new GridBlock(i,j,k));
				}
			}
		} 
	}
}
