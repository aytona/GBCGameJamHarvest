using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipThrusters : MonoBehaviour {

    /// <summary>
    /// Reference to all levers that controls the ship
    /// </summary>
    public GameObject m_PitchLever;
    public GameObject m_YawLever;
    public GameObject m_RollLever;
    public GameObject m_ThrustLever;

    /// <summary>
    /// Force applied to this object depending on lever rotation
    /// </summary>
    private Vector3 m_Force = Vector3.zero;

    /// <summary>
    /// Reference to ship's rigidbody
    /// </summary>
    private Rigidbody m_rb;

    void Start() {
        m_rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        m_Force.x = m_ThrustLever.GetComponent<ControlLever>().GetRotation();
        m_rb.AddTorque( m_YawLever.GetComponent<ControlLever>().GetRotation(), m_RollLever.GetComponent<ControlLever>().GetRotation(), m_PitchLever.GetComponent<ControlLever>().GetRotation(), ForceMode.Impulse);
        m_rb.AddForce(m_Force, ForceMode.Impulse);
    }
}