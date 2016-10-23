using UnityEngine;

public class ControlLever : MonoBehaviour {

    /// <summary>
    /// Final rotation value of lever
    /// </summary>
    private float m_rotationValue;

    /// <summary>
    /// The clamp rot
    /// </summary>
    public float m_ClampRot;

    void Update() {
        if (transform.localRotation.z > m_ClampRot) {
            Quaternion target = Quaternion.Euler(0.0f, 0.0f, m_ClampRot);
            transform.localRotation = target;
        } else if(transform.localRotation.z < -m_ClampRot) {
            Quaternion target = Quaternion.Euler(0.0f, 0.0f, -m_ClampRot);
            transform.localRotation = target;
        }

        if(transform.localRotation.z < -Mathf.Epsilon || transform.localRotation.z > Mathf.Epsilon) {
            m_rotationValue = -transform.localRotation.z;
        } else {
            m_rotationValue = 0.0f;
        }
    }

    public float GetRotation() {
        return m_rotationValue;
    }
}