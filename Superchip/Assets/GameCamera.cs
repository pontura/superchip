using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

    public Character character;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.localPosition;
        pos.x = character.transform.localPosition.x;
        transform.localPosition = pos;
	}
}
