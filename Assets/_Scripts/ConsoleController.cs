using UnityEngine;

public class ConsoleController : MonoBehaviour {

    /// <summary>
    /// All 4 levers on the console
    /// </summary>
    public GameObject m_PitchLever;
    public GameObject m_RollLever;
    public GameObject m_YawLever;
    public GameObject m_ThrustLever;

    public float m_RotationClamp;

    private float m_RotationSpeed = 80.0f;
    private float m_smooth = 5.0f;

    void Update() {
        ProcessInput();
        Reset2Origin();
    }

    void ProcessInput() {

        // Pitch
        if(Input.GetKey(KeyCode.W)) {
            Quaternion m_Pitch = Quaternion.Euler(0.0f, 0.0f, m_PitchLever.transform.localRotation.z - m_RotationSpeed);
            m_PitchLever.transform.localRotation = Quaternion.Slerp(m_PitchLever.transform.localRotation, m_Pitch, Time.deltaTime * m_smooth);
        } else if(Input.GetKey(KeyCode.S)) {
            Quaternion m_Pitch = Quaternion.Euler(0.0f, 0.0f, m_PitchLever.transform.localRotation.z + m_RotationSpeed);
            m_PitchLever.transform.localRotation = Quaternion.Slerp(m_PitchLever.transform.localRotation, m_Pitch, Time.deltaTime * m_smooth);
        }

        // Roll
        if(Input.GetKey(KeyCode.A)) {
            Quaternion m_Roll = Quaternion.Euler(0.0f, 0.0f, m_RollLever.transform.localRotation.z - m_RotationSpeed);
            m_RollLever.transform.localRotation = Quaternion.Slerp(m_RollLever.transform.localRotation, m_Roll, Time.deltaTime * m_smooth);
        } else if(Input.GetKey(KeyCode.D)) {
            Quaternion m_Roll = Quaternion.Euler(0.0f, 0.0f, m_RollLever.transform.localRotation.z + m_RotationSpeed);
            m_RollLever.transform.localRotation = Quaternion.Slerp(m_RollLever.transform.localRotation, m_Roll, Time.deltaTime * m_smooth);
        }

        // Yaw
        if(Input.GetKey(KeyCode.LeftArrow)) {
            Quaternion m_Yaw = Quaternion.Euler(0.0f, 0.0f, m_YawLever.transform.localRotation.z - m_RotationSpeed);
            m_YawLever.transform.localRotation = Quaternion.Slerp(m_YawLever.transform.localRotation, m_Yaw, Time.deltaTime * m_smooth);
        } else if(Input.GetKey(KeyCode.RightArrow)) {
            Quaternion m_Yaw = Quaternion.Euler(0.0f, 0.0f, m_YawLever.transform.localRotation.z + m_RotationSpeed);
            m_YawLever.transform.localRotation = Quaternion.Slerp(m_YawLever.transform.localRotation, m_Yaw, Time.deltaTime * m_smooth);
        }

        // Velocity
        if(Input.GetKey(KeyCode.UpArrow)) {
            Quaternion m_Velocity = Quaternion.Euler(0.0f, 0.0f, m_ThrustLever.transform.localRotation.z - m_RotationSpeed);
            m_ThrustLever.transform.localRotation = Quaternion.Slerp(m_ThrustLever.transform.localRotation, m_Velocity, Time.deltaTime * m_smooth);
        } else if(Input.GetKey(KeyCode.DownArrow)) {
            Quaternion m_Velocity = Quaternion.Euler(0.0f, 0.0f, m_ThrustLever.transform.localRotation.z + m_RotationSpeed);
            m_ThrustLever.transform.localRotation = Quaternion.Slerp(m_ThrustLever.transform.localRotation, m_Velocity, Time.deltaTime * m_smooth);
        }
    }

    void Reset2Origin() {
        if(m_PitchLever.transform.localRotation.z > Mathf.Epsilon || m_PitchLever.transform.localRotation.z < -Mathf.Epsilon) {
            m_PitchLever.transform.localRotation = Quaternion.Slerp(m_PitchLever.transform.localRotation, Quaternion.identity, Time.deltaTime * m_smooth * 0.75f);
        }

        if(m_RollLever.transform.localRotation.z > Mathf.Epsilon || m_RollLever.transform.localRotation.z < -Mathf.Epsilon) {
            m_RollLever.transform.localRotation = Quaternion.Slerp(m_RollLever.transform.localRotation, Quaternion.identity, Time.deltaTime * m_smooth * 0.75f);
        }

        if(m_YawLever.transform.localRotation.z > Mathf.Epsilon || m_YawLever.transform.localRotation.z < -Mathf.Epsilon) {
            m_YawLever.transform.localRotation = Quaternion.Slerp(m_YawLever.transform.localRotation, Quaternion.identity, Time.deltaTime * m_smooth * 0.75f);
        }

        if(m_ThrustLever.transform.localRotation.z > Mathf.Epsilon || m_ThrustLever.transform.localRotation.z < -Mathf.Epsilon) {
            m_ThrustLever.transform.localRotation = Quaternion.Slerp(m_ThrustLever.transform.localRotation, Quaternion.identity, Time.deltaTime * m_smooth * 0.75f);
        }
    }
}
