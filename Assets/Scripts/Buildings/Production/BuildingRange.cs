using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingRange {

    private int x;
    private int y;
    private int range;

    public BuildingRange(int x, int y, int range) {
        this.x = x;
        this.y = y;
        this.range = range;
    }

    /// <summary>
    /// Calculate the fields which are within the range of the given x and y coordinates.
    /// </summary>
    /// <param name="adjacentFields">Holds the calculated fields which are in the range around the building</param>
    /// <returns></returns>
    public void calculateAdjacentFields(out List<GameObject> adjacentFields) {
        adjacentFields = new List<GameObject>();

        for (int x1 = x - range; x1 < x + range; x1++) {
            for (int y1 = y - range; y1 < y + range; y1++) {
                GameObject obj = GameObject.Find("Tile" + x1.ToString() + "," + y1.ToString());
                if (obj) {
                    adjacentFields.Add(obj);
                }
            }
        }
    }
}
