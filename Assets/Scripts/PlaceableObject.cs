using UnityEngine;
using System;
using System.Collections;

public class PlaceableObject : MonoBehaviour {

    public const int PLACEMENT_SLOT_NONE = -1;
	public const int PLACEMENT_SLOT_WHOLE = 0;
	public const int PLACEMENT_SLOT_WALL_UP = 1;
	public const int PLACEMENT_SLOT_WALL_DOWN = 2;
	public const int PLACEMENT_SLOT_WALL_FRONT = 3;
	public const int PLACEMENT_SLOT_WALL_BACK = 4;
	public const int PLACEMENT_SLOT_WALL_RIGHT = 5;
	public const int PLACEMENT_SLOT_WALL_LEFT = 6;

	public enum Slot
	{
        None = PLACEMENT_SLOT_NONE,
		Whole_Block = PLACEMENT_SLOT_WHOLE,
		Ceiling_Slot = PLACEMENT_SLOT_WALL_UP,
		Floor_Slot = PLACEMENT_SLOT_WALL_DOWN,
		Front_Wall_Slot = PLACEMENT_SLOT_WALL_FRONT,
		Back_Wall_Slot = PLACEMENT_SLOT_WALL_BACK,
		Right_Wall_Slot = PLACEMENT_SLOT_WALL_RIGHT,
		Left_Wall_Slot = PLACEMENT_SLOT_WALL_LEFT
	}

    [SerializeField]
    private Slot occupyingSlot = Slot.None;

    public Slot[] PossiblePlacementLocations;

    public Slot OccupyingSlot
    {
        get { return occupyingSlot; }
        set
        {
            foreach(Slot possibleSlot in PossiblePlacementLocations)
            {
                if(possibleSlot == value)
                {
                    occupyingSlot = value;
                    return;
                }
            }

            Debug.LogError("Tried to set an invalid slot location for object " + gameObject.ToString());
        }
    }


}
