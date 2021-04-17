using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
	public Transform targ;

	Vector3 startdist, movevec;

	public Vector3 offset;

	// Use this for initialization
	void Start()
	{
		startdist = transform.position - targ.position;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		movevec = targ.position + startdist;
		movevec.z = 0;
		movevec.y = startdist.y;
		transform.position = movevec;
	
	}
}