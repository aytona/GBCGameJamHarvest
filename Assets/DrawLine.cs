using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour {

    private LineRenderer m_line;
    public Transform target;

	// Use this for initialization
	void Start () {
        m_line = GetComponent<LineRenderer>();
        
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(KeyCode.Space))
        {
            m_line.SetPosition(0, transform.position);
            m_line.SetPosition(1, target.position);
        }
        else
        {
            m_line.SetPosition(0, transform.position);
            m_line.SetPosition(1, transform.position);
        }
	}
}
