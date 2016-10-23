using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class AsteroidPhysics : MonoBehaviour {

    public float m_minForce, m_maxForce;

    private Rigidbody m_rb;
    private Vector3 m_force;
    private Vector3 m_rotationAxis;

	void Start () {
        m_rb = GetComponent<Rigidbody>();

        m_force = GetRandomForce(m_minForce, m_maxForce) * GetRandomVector();
        m_rotationAxis = GetRandomVector();

        m_rb.AddForce(m_force);
	}

    void Update()
    {
        transform.Rotate(m_rotationAxis * Time.deltaTime);
    }

    private float GetRandomForce(float min, float max)
    {
        return Random.Range(min, max);
    }

    private Vector3 GetRandomVector()
    {
        Vector3 newDir = Vector3.zero;
        newDir.x = Random.Range(-1.0f, 1.0f);
        newDir.y = Random.Range(-1.0f, 1.0f);
        newDir.z = Random.Range(-1.0f, 1.0f);

        return newDir;
    }
}
