using UnityEngine;
using System.Collections.Generic;

public class GridBlock {
	private float x,y,z;
	private List<GameObject> containedObjects;

	private List<bool> occupiedSlots;

	public GridBlock (float _x, float _y, float _z)
	{
		x = _x;
		y = _y;
		z = _z;

		containedObjects = new List<GameObject>();
		occupiedSlots = new List<bool>();
		//TODO: fill the bools from PlaceableObject constants
	}

	public void AddObject(GameObject object)
	{
		PlaceableObject plObject = object.GetComponent<PlaceableObject>();
		if(plObject == null)
		{
			Debug.Error(object.ToString() + " is not placeable! Attach PlaceableObject script.");
		}

		if(NewObjectHasRoom(plObject))
		{
			containedObjects.Add(object);
			occupiedSlots[plObject.Slot] = true;
		}	
	}

	public void RemoveObject(GameObject object)
	{
		int found = containedObjects.IndexOf(object);
		if(found)
		{
			PlaceableObject plObject = object.GetComponent<PlaceableObject>();
			occupiedSlots[plObject.Slot] = false;
			containedObjects.RemoveAt(found);
		}
		else
		{
			Debug.Error("Cannot remove object: " + object.ToString() + " does not exist in GridBlock " + x.ToString() + ", " + y.ToString() + ", " + z.ToString() + ".");
		}
	}

	private bool NewObjectHasRoom(PlaceableObject object)
	{
		return !occupiedSlots[object.Slot];
	}

	public float X { get; set; }
	public float Y { get; set; }
	public float Z { get; set; }
	public bool OccupiedWhole { get {return occupiedWhole;}}
	public bool OccupiedTop { get {return occupiedTop;}}
	public bool OccupiedBottom { get {return occupiedBottom;}}
	public bool OccupiedFront { get {return occupiedFront;}}
	public bool OccupiedBack { get {return occupiedBack;}}
	public bool OccupiedRight { get {return occupiedRight;}}
	public bool OccupiedLeft { get {return occupiedLeft;}}
}
