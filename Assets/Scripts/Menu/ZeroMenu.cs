using UnityEngine;
using UnityEngine.UI;

public class ZeroMenu : MonoBehaviour {

    public Building house;

    public Building woodCutter;
    public Building forest;
    public Building farm;
    public Building wheat;

    public bool building = false;
    public float size = 1.25f;
    public GameObject standardBuildingsPanel;
    public GameObject productionBuildingsPanel;

    private Building go;
    private GameObject objAtPosition;
    private float buildingOffset = -5f; //Offset, so higher up buildings get displayed correctly (Otherwise they would overlap)
	
	// Update is called once per frame
	void Update () {
        if (building) {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 1f;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                Vector3 position = hit.transform.position;
                objAtPosition = hit.transform.gameObject;
                position.z = buildingOffset + position.y * 0.05f;

                go.transform.position = position;
            }

            if (Input.GetMouseButtonDown(1)) {
                building = false;

                Destroy(go);
            }
            else if (Input.GetMouseButtonDown(0)) {
                building = false;

                go.gameObject.name = objAtPosition.name;
                go.placeBuilding();
            }
        }
	}

    public void ToggleBuildMenu() {
        transform.gameObject.SetActive(!transform.gameObject.activeSelf);
    }

    public void ToggleStandardBuildings() {
        productionBuildingsPanel.SetActive(false);
        standardBuildingsPanel.SetActive(!standardBuildingsPanel.activeSelf);
    }

    public void ToggleProductionBuildings() {
        standardBuildingsPanel.SetActive(false);
        productionBuildingsPanel.SetActive(!productionBuildingsPanel.activeSelf);
    }

    public void BuildHouse() {
        building = true;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0f;

        go = (Building) Instantiate(house, mousePosition, new Quaternion());
        go.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    public void BuildWoodcutter() {
        building = true;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0f;

        go = (Building)Instantiate(woodCutter, mousePosition, new Quaternion());
        go.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    public void BuildForest() {
        building = true;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0f;

        go = (Building)Instantiate(forest, mousePosition, new Quaternion());
        go.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    public void build(Building buildObject) {
        building = true;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0f;

        go = (Building)Instantiate(buildObject, mousePosition, new Quaternion());
        setLayerRecursive(go.gameObject, LayerMask.NameToLayer("Ignore Raycast"));
    }

    private void setLayerRecursive(GameObject obj, int layer) {
        obj.layer = layer;

        foreach (Transform child in obj.transform) {
            setLayerRecursive(child.gameObject, layer);
        }
    }
}
