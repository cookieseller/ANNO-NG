using UnityEngine;

public class CreateMap : MonoBehaviour {

    public int mapSize = 5;       // Means 128*128
    public float tileSize = 1.25f;
    public GameObject[] grassTiles;
    public string mapName = "Map";
    public string tileName = "Tile";

	// Use this for initialization
	void Start () {

        GameObject map = new GameObject();
        map.name = mapName;

        for (int x = 0; x < mapSize; x++) {
            float yOffset = x % 2 == 1 ? 0.62f : 0f;
            for (int y = 0; y < mapSize; y++) {
                GameObject obj = (GameObject) Instantiate(grassTiles[0], new Vector3(x * tileSize, y * tileSize + yOffset, 0f), new Quaternion());
                obj.transform.parent = map.transform;
                obj.name = tileName + x.ToString() + "," + y.ToString();
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
