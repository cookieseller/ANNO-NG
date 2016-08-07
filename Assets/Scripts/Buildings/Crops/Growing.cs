using UnityEngine;
using System.Collections;

public class Growing : FieldBuilding {

    public bool growing = true; //Whether the field has a growing state, like e.g. wood
    public float growthSpeed = 10.0f; //Grows by one every 10 seconds
    public Transform[] growthStates; //Where 0 is the first state and n is the last
    private int currentCircle = 0;

    protected override void instantiateBuilding(int x, int y) {
        if (growthStates.Length <= 0) {
            Debug.Log("No growth states defined for: " + transform.gameObject.name);
            return;
        }

        InvokeRepeating("growthCycle", growthSpeed, growthSpeed);
    }

    public void harvest() {
        currentCircle = -1;
    }

    private void growthCycle() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
        if (growthStates.Length <= currentCircle) {
            return;
        }
        //go = (Building)Instantiate(house, mousePosition, new Quaternion());
        Transform obj = (Transform) Instantiate(growthStates[++currentCircle], new Vector3(), new Quaternion());
        obj.transform.parent = transform;
        obj.transform.localPosition = new Vector3();
    }
}
