using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MeshFilter))]
public class PlayerRadius : MonoBehaviour {

    public int m_maxObjectToSpawn = 100;
    public int m_maxToNewSpawn = 20;
    public float m_distanceUntilSpawn = 15.0f;

    public GameObject m_asteroidSmall, m_asteroidMedium, m_astroidLarge, m_asteroidXLarge;

    public float m_smlPrcnt, m_medPrcnt, m_lrgPrcnt, m_xlPrcnt;

    private MeshFilter m_sphere;
    private Vector3 m_prevPosition;
    private Vector3 m_bounds;
    private ShipThrusters m_ship;

	void Start () {
        m_ship = FindObjectOfType<ShipThrusters>();
        m_sphere = GetComponent<MeshFilter>();
        m_prevPosition = transform.position;
        m_bounds = m_sphere.sharedMesh.bounds.extents;

        InitialSpawn();
	}

    void Update()
    {
        if(Vector3.Distance(m_prevPosition, transform.position) > m_distanceUntilSpawn)
        {
            NewSpawn();
            m_prevPosition = transform.position;
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * 10.0f * Time.deltaTime);
        }

        transform.position = m_ship.transform.position;
        transform.rotation = m_ship.transform.rotation;
    }

    private void InitialSpawn()
    {

        for (int i = 0; i < (int)(m_maxObjectToSpawn * m_smlPrcnt); i++)
        {
            SpawnObjectsInit(m_asteroidSmall);
        }

        for (int i = 0; i < (int)(m_maxObjectToSpawn * m_medPrcnt); i++)
        {
            SpawnObjectsInit(m_asteroidMedium);
        }

        for (int i = 0; i < (int)(m_maxObjectToSpawn * m_lrgPrcnt); i++)
        {
            SpawnObjectsInit(m_astroidLarge);
        }

        for (int i = 0; i < (int)(m_maxObjectToSpawn * m_xlPrcnt); i++)
        {
            SpawnObjectsInit(m_asteroidXLarge);
        }
    }

    private void NewSpawn()
    {
        for (int i = 0; i < (int)(m_maxToNewSpawn * m_smlPrcnt); i++)
        {
            SpawnObjects(m_asteroidSmall);
        }

        for (int i = 0; i < (int)(m_maxToNewSpawn * m_medPrcnt); i++)
        {
            SpawnObjects(m_asteroidMedium);
        }

        for (int i = 0; i < (int)(m_maxToNewSpawn * m_lrgPrcnt); i++)
        {
            SpawnObjects(m_astroidLarge);
        }

        for (int i = 0; i < (int)(m_maxToNewSpawn * m_xlPrcnt); i++)
        {
            SpawnObjects(m_asteroidXLarge);
        }
    }

    private void SpawnObjectsInit(GameObject asteroid)
    {
        Vector3 newPos = Vector3.zero;
        newPos.x = Random.Range(transform.position.x - m_bounds.x, transform.position.x + m_bounds.x);
        newPos.y = Random.Range(transform.position.y - m_bounds.y, transform.position.y + m_bounds.y);
        newPos.z = Random.Range(transform.position.z - m_bounds.z, transform.position.z + m_bounds.z);

        Instantiate(asteroid, transform.TransformPoint(newPos), Random.rotation);
    }

    private void SpawnObjects(GameObject asteroid)
    {
        Vector3 newPos = Vector3.zero;
        newPos.x = Random.Range(0 + (m_bounds.x * 0.8f), m_bounds.x);
        newPos.y = Random.Range(0 - m_bounds.y, m_bounds.y);
        newPos.z = Random.Range(0 - m_bounds.z, m_bounds.z);

        Instantiate(asteroid, transform.TransformPoint(newPos), Random.rotation);
    }
}
