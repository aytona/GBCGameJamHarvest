using UnityEngine;
using System.Collections;

public class TargetingSystem : MonoBehaviour {

    public float m_targetingDistance;
    public float m_targetingTime = 2.0f;

    public GameObject m_torpedo;
    public Transform m_torpedoSpawn = null;

    private GameObject m_targetedObject = null;
    private float m_targetingCount = 0.0f;
    private bool m_isTargeted = false;

	void FixedUpdate () {
        if(Input.GetKey(KeyCode.Space))
        {
            Target();
        }

	}

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Fire();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * 10.0f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * 10.0f * Time.deltaTime);
        }
    }

    private void Target()
    {
        if (!m_isTargeted)
        {
            RaycastHit hit;

            Debug.DrawRay(transform.position, transform.forward * m_targetingDistance, Color.green, Time.deltaTime);
            if (Physics.Raycast(transform.position, transform.forward, out hit, m_targetingDistance))
            {
                if (m_targetedObject == null)
                {
                    if (hit.transform.GetComponent<AsteroidPhysics>())
                    {
                        m_targetedObject = hit.transform.gameObject;
                    }
                }
                else
                {
                    if (m_targetedObject == hit.transform.gameObject)
                    {
                        m_targetingCount += Time.deltaTime;

                        if (m_targetingCount >= m_targetingTime)
                        {
                            m_isTargeted = true;
                            hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;
                        }
                    }
                    else
                    {
                        m_targetedObject = hit.transform.gameObject;
                        m_targetingCount = 0.0f;
                    }
                }
            }
        }
    }

    private void Fire()
    {
        if(m_isTargeted)
        {
            GameObject torpedo = Instantiate(m_torpedo, m_torpedoSpawn.position, Quaternion.identity) as GameObject;
            if (torpedo != null)
                torpedo.GetComponent<Torpedo>().SetTarget(m_targetedObject.transform);
            m_isTargeted = false;
        }
        else
        {
            m_isTargeted = false;
            m_targetingCount = 0.0f;
            Torpedo torpedo = Instantiate(m_torpedo, m_torpedoSpawn.position, Quaternion.identity) as Torpedo;
        }
    }
}
