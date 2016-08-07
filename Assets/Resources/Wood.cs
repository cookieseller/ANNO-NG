using UnityEngine;
using UnityEngine.UI;

public class Wood : MonoBehaviour {

    Text woodText;
    ResourceStore resourceStore;

	// Use this for initialization
	void Start () {
        GameObject obj = GameObject.Find("ResourceStore");
        resourceStore = obj.GetComponent<ResourceStore>();

    }

    void Awake() {
        woodText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        woodText.text = resourceStore.getResourceWood().ToString();
	}
}
