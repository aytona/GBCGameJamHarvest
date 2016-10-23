using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class Torpedo : MonoBehaviour {

    public float m_maxDistanceToShip = 15.0f;
    public float m_speed = 150.0f;

    private Transform m_target;
    private Vector3 m_initialPosition;
    private Rigidbody m_rb;

	// Use this for initialization
	void Start () {
        m_rb = GetComponent<Rigidbody>();
        m_initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Seek();
	}

    void OnCollisionEnter()
    {
        // Explode
        Destroy(this.gameObject);
    }

    private void Seek()
    {
        if (m_target != null)
        {
            if (Vector3.Distance(m_initialPosition, transform.position) < m_maxDistanceToShip)
            {
                transform.LookAt(m_target.transform.position);
            }
        }

        if(m_rb.velocity.magnitude < m_speed)
        {
            m_rb.AddForce(transform.forward * m_speed * Time.deltaTime, ForceMode.Force);
        }
    }

    public void SetTarget(Transform target)
    {
        m_target = target;
    }

    IEnumerator DestroyCount()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(this.gameObject);
    }
}
