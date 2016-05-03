using UnityEngine;
using System;
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
        
        foreach(PlaceableObject.Slot slot in Enum.GetValues(typeof(PlaceableObject.Slot)))
        {
            if(slot != PlaceableObject.Slot.None)
            {
                occupiedSlots.Insert((int)slot, false);
            }
        }
	}

	public void AddObject(GameObject gameObject)
	{
		PlaceableObject plObject = gameObject.GetComponent<PlaceableObject>();
		if(plObject == null)
		{
			Debug.LogError(gameObject.ToString() + " is not placeable! Attach PlaceableObject script.");
		}

		if(NewObjectHasRoom(plObject))
		{
            if (plObject.OccupyingSlot != PlaceableObject.Slot.None)
            {
                containedObjects.Add(gameObject);
                occupiedSlots[(int)plObject.OccupyingSlot] = true;
            }
		}	
	}

	public void RemoveObject(GameObject gameObject)
	{
		int found = containedObjects.IndexOf(gameObject);
		if(found >= 0)
		{
            PlaceableObject plObject = gameObject.GetComponent<PlaceableObject>();
            if (plObject.OccupyingSlot != PlaceableObject.Slot.None)
            {
                occupiedSlots[(int)plObject.OccupyingSlot] = false;
                containedObjects.RemoveAt(found);
            }
		}
		else
		{
			Debug.LogError("Cannot remove object: " + gameObject.ToString() + " does not exist in GridBlock " + x.ToString() + ", " + y.ToString() + ", " + z.ToString() + ".");
		}
	}

	private bool NewObjectHasRoom(PlaceableObject plObject)
	{
        if (plObject.OccupyingSlot != PlaceableObject.Slot.None)
        {
            return !occupiedSlots[(int)plObject.OccupyingSlot];
        }
        else
        {
            return false;
        }
	}

	public float X { get; set; }
	public float Y { get; set; }
	public float Z { get; set; }
}
