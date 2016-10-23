using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class TestProjectile : MonoBehaviour {

    private Rigidbody m_rb;

    public float Force;

	// Use this for initialization
	void Start () {
        m_rb = GetComponent<Rigidbody>();

        m_rb.AddForce(Vector3.left * Force);
	}
	
}
