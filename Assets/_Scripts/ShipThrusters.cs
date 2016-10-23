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
    public float speed;

    /// <summary>
    /// Force applied to this object depending on lever rotation
    /// </summary>
    private Vector3 m_Force = Vector3.zero;

    /// <summary>
    /// Reference to ship's rigidbody
    /// </summary>
    private Rigidbody m_rb;

    private Fuel m_fuel;

    void Start() {
        m_rb = GetComponent<Rigidbody>();
        m_fuel = FindObjectOfType<Fuel>();
    }

    void FixedUpdate() {
        if (m_fuel.currentFuel > 0)
        {
            m_Force.x = m_ThrustLever.GetComponent<ControlLever>().GetRotation();
            m_rb.AddRelativeTorque(m_YawLever.GetComponent<ControlLever>().GetRotation(), m_RollLever.GetComponent<ControlLever>().GetRotation(), m_PitchLever.GetComponent<ControlLever>().GetRotation(), ForceMode.Impulse);
            m_rb.AddRelativeForce(m_Force * speed, ForceMode.Impulse);

            if (Mathf.Abs(m_Force.x) > 0.1f)
                m_fuel.UseFuel();

        }
    }
}