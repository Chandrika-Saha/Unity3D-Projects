using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class road : MonoBehaviour {
	public GameObject[] fabs;//prefab folder array
	private Transform runnerTrans;//finds runner's position
	private float Zaxis = -22.2f;//calculate z axix length for finding out weather a block has passed or not
	private float blocklen = 44.4f;//length of a block
	private int amountScreen = 7;//7 blocks will be displayed at a time
	private float safeBlock = 44.5f;
	private List<GameObject> activeBolcks;//how many roads are active now
	private int lastFab = 0;

	// Use this for initialization
	private void Start () {
		activeBolcks = new List<GameObject>();
		runnerTrans = GameObject.FindGameObjectWithTag ("runner").transform;//getting runners position
		for (int i = 0; i < amountScreen; i++) {
			if (i <= 1)
				insBlock (0);
			else
				insBlock ();
		}//adding blocks
	}
	
	// Update is called once per frame
	private void Update () {
		
		if((runnerTrans.position.z - safeBlock) > (Zaxis - blocklen*amountScreen))//if the length ran by the player is grater then the calculated z axis - total onscreen block length then tiles is created
			{
			//create a new block whenever a block is passed
				insBlock ();
				delBlock ();
			}
	}
	private void insBlock (int fabIndex=-1)
	{
		GameObject road;
		if (fabIndex == -1)
			road = Instantiate (fabs [randomFab ()]) as GameObject;
		else
			road = Instantiate (fabs [fabIndex]) as GameObject;
		road.transform.SetParent (transform);
		road.transform.position = Vector3.forward * Zaxis;
		Zaxis += blocklen;
		activeBolcks.Add (road);
	}
	private void delBlock()
	{
		Destroy (activeBolcks [0]);
		activeBolcks.RemoveAt (0);
	}

	private int randomFab()
	{
		if (fabs.Length <= 1)
			return 0;
		int randomIn = lastFab;
		while (randomIn == lastFab) {
			randomIn = Random.Range (0, fabs.Length);
		}
		lastFab = randomIn;
		return randomIn;
	}
}
