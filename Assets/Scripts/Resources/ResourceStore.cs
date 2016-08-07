using UnityEngine;
using System.Collections;

public class ResourceStore : MonoBehaviour {

    private int wood;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void increaseWood() {
        wood++;
    }

    public int getResourceWood() {
        return wood;
    }
}
