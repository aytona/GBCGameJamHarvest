using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class AsteroidTractorBeam : MonoBehaviour {

    private Rigidbody m_rb;
    private Transform m_attractor;
    private bool m_inTractorBeam = false;
    private float m_tractorBeamStrength = 1.0f;

	void Start () {
        m_rb = GetComponent<Rigidbody>();
	}

    public void Attracted()
    {
        Vector3 dir = m_attractor.position - transform.position;
        dir.Normalize();
        m_rb.AddForce(dir * m_tractorBeamStrength);
    }

    public void ActivateAttract(Transform attractor, float beamStrength, bool isInBeam)
    {
        m_inTractorBeam = isInBeam;
        m_attractor = attractor;
        m_tractorBeamStrength = beamStrength;
    }
}
