using UnityEngine;

public class UILookAt : MonoBehaviour {

    public Transform m_Target;

    void Start() {
        transform.LookAt(m_Target.position);
        Quaternion m_targetRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + 45f, transform.rotation.z);
        transform.rotation = m_targetRotation;
    }
}
