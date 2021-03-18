using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{

	public Rigidbody hook;

	public GameObject linkPrefab;

	public Weight weigth;

	public int links = 7;

	//public Transform[] children;
	public LineRenderer line;
	List<GameObject> children = new List<GameObject>();

	void Start()
	{
		line = gameObject.GetComponent<LineRenderer>();


		GenerateRope();


		GetLinePositions();
	}

	void GenerateRope()
	{

		//Segments for physics
		Rigidbody previousRB = hook;
		for (int i = 0; i < links; i++)
		{
			GameObject link = Instantiate(linkPrefab, transform);
			HingeJoint joint = link.GetComponent<HingeJoint>();
			joint.connectedBody = previousRB;

			//previousRB = link.GetComponent<Rigidbody>();

			if (i < links - 1)
			{
				previousRB = link.GetComponent<Rigidbody>();
			}
			else
			{
				weigth.ConnectRopeEnd(link.GetComponent<Rigidbody>());
			}


		}

		//Line segments
		line.positionCount = links;
	}

	public void GetLinePositions()
    {
		/*		for (int j = 0; j < links; j++)
				{
					children[j] = gameObject.transform.GetChild(j);
				}*/
		foreach (Transform child in this.gameObject.transform)
		{
			children.Add(child.gameObject);
		}
	}

	void LateUpdate()
	{
		if (line.enabled)
        {
			CheckLen();
			for (int i = 0; i < links; i++)
			{
				line.SetPosition(i, children[i].transform.position);
			}
		}

	}

	void CheckLen()
    {
		if (children.Count < links)
		{
			line.enabled = false;
		}
	}

}