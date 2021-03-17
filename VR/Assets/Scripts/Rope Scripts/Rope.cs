using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{

	public Rigidbody hook;

	public GameObject linkPrefab;

	//public Weight weigth;

	public int links = 7;

	void Start()
	{
		GenerateRope();
	}

	void GenerateRope()
	{
		Rigidbody previousRB = hook;
		for (int i = 0; i < links; i++)
		{
			GameObject link = Instantiate(linkPrefab, transform);
			HingeJoint joint = link.GetComponent<HingeJoint>();
			joint.connectedBody = previousRB;

			previousRB = link.GetComponent<Rigidbody>();

			/*			if (i < links - 1)
						{
							previousRB = link.GetComponent<Rigidbody>();
						}
						else
						{
							weigth.ConnectRopeEnd(link.GetComponent<Rigidbody>());
						}*/


		}
	}

}