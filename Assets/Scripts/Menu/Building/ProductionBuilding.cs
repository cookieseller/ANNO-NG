using UnityEngine;
using System.Collections.Generic;

public class ProductionBuilding : Building {

    public float resourceGain = 10f; // After this amount of time 1 resource is producedS
    public string resourceFieldTag = ""; // If and adjacent field has this tag, it is usable for resource generation
    public int range = 3; // Amount of fields around the Building which can be used to for production

    private ResourceStore resourceStore;
    private BuildingRange buildingRange;
    private List<GameObject> adjacentFields;
    private float deltaTime = 0f;

    protected override void instantiateBuilding(int x, int y) {

        GameObject obj = GameObject.Find("ResourceStore");
        resourceStore = obj.GetComponent<ResourceStore>();

        buildingRange = new BuildingRange(x, y, range);
        buildingRange.calculateAdjacentFields(out adjacentFields);
    }

    // Update is called once per frame
    void Update() {
        if (adjacentFields == null) {
            return;
        }

        foreach (GameObject field in adjacentFields) {
            if (field.tag == resourceFieldTag) {
                deltaTime += Time.deltaTime;
                if (deltaTime > resourceGain) {
                    resourceStore.increaseWood();
                }
            }
        }
    }
}
