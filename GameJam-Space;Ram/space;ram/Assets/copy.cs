using UnityEngine;
using System.Collections;

public class copy : MonoBehaviour {
    public SpriteRenderer target;
    public SpriteRenderer rend;
	// Use this for initialization
	void Start () {
        rend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (target.enabled == true)
        {
            rend.enabled = true;
        }
        else
        {
            rend.enabled = false;
        }

	}
}
