using UnityEngine;
using System.Text.RegularExpressions;

public abstract class Building : MonoBehaviour
{
    public void placeBuilding() {

        Match match = Regex.Match(transform.name, @".*?(\d)+,(\d)+");
        if (match.Success && match.Groups.Count == 3) {
            int x = int.Parse(match.Groups[1].Value);
            int y = int.Parse(match.Groups[2].Value);

            instantiateBuilding(x, y);
        }
        else {
            Debug.Log("Match Failed for name " + transform.name);
        }
    }

    protected abstract void instantiateBuilding(int x, int y);
}
