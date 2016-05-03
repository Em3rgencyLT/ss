using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using System;

public class WorldGrid : NetworkBehaviour {
	
	[SerializeField]
	private int xSize,ySize,zSize;
    private  Dictionary<Vector3, GridBlock> grid;

    private int gridToCoordinateRatio = 3;

    public GameObject blockPrefab;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        ClientScene.RegisterPrefab(blockPrefab);
    }

    void Start()
	{
		grid = new Dictionary<Vector3, GridBlock>();
        if(xSize > 0 && ySize > 0 && zSize > 0)
        {
            InitializeWorldGrid();
        }
	}
	
	private void InitializeWorldGrid()
	{
        //0,0,0 is the center
        for (int k = (int)Mathf.Ceil((Math.Abs(zSize)/-2f)); k < (int)Mathf.Ceil((Math.Abs(zSize)/2f)); k++)
		{
            for (int j = (int)Mathf.Ceil((Math.Abs(ySize)/-2f)); j < (int)Mathf.Ceil((Math.Abs(ySize)/2f)); j++)
			{
                for (int i = (int)Mathf.Ceil((Math.Abs(xSize)/-2f)); i < (int)Mathf.Ceil((Math.Abs(xSize)/2f)); i++)
				{
                    GridBlock gridBlock = new GridBlock(i, j, k);

                    if (isServer)
                    {
                        GameObject gameObject = (GameObject)Instantiate(blockPrefab, GridToWorldCoordinates(i, j-1, k), Quaternion.identity);
                        PlaceableObject plObject = gameObject.GetComponent<PlaceableObject>();
                        plObject.OccupyingSlot = PlaceableObject.Slot.Whole_Block;
                        gridBlock.AddObject(gameObject);
                        NetworkServer.Spawn(gameObject);
                    }

                    grid.Add(new Vector3(i,j,k), gridBlock);
				}
			}
		} 
	}

    public Vector3 GridToWorldCoordinates(int x, int y, int z)
    {
        return new Vector3((float)x, (float)y, (float)z)*gridToCoordinateRatio;
    }
}
