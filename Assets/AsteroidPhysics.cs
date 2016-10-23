using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class AsteroidPhysics : MonoBehaviour {

    public float m_minForce, m_maxForce;
    public GameObject explosion;

    private Rigidbody m_rb;
    private Vector3 m_force;
    private Vector3 m_rotationAxis;
    private Fuel m_fuel;


	void Start () {
        m_rb = GetComponent<Rigidbody>();
        m_fuel = FindObjectOfType<Fuel>();

        m_force = GetRandomForce(m_minForce, m_maxForce) * GetRandomVector();
        m_rotationAxis = GetRandomVector();

        m_rb.AddForce(m_force);
	}

    void Update()
    {
        transform.Rotate(m_rotationAxis * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.collider.CompareTag("Torpedo"))
        {
            m_fuel.AddFuel(0.15f);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
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
