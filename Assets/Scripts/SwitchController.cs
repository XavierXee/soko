using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{

	void OnCollisionEnter(Collision collision)
    {
		print("No longer in contact with " + collision.transform.name);
    }

 	void OnCollisionExit(Collision collision)
    {
        print("No longer in contact with " + collision.transform.name);
    }
}
