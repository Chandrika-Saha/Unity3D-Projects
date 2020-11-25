using UnityEngine;
using System.Collections;

public class destroy : MonoBehaviour {

	// Use this for initialization
    public float lifetime;
	void Start () {
        Destroy(gameObject, lifetime);
	}
	

}
