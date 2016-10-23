using UnityEngine;
using System.Collections;

public class TractorBeam : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {
        ActivateTractorBeam();
	}

    public void ActivateTractorBeam()
    {
        RaycastHit hit;
        AsteroidTractorBeam t = null;
        
        Debug.DrawRay(transform.position, transform.forward * 10.0f, Color.red, Time.deltaTime);
        if(Physics.Raycast(transform.position, transform.forward * 10.0f, out hit,  50.0f))
        {
            if(hit.transform.GetComponent<AsteroidTractorBeam>())
            {
                t = hit.transform.GetComponent<AsteroidTractorBeam>();
                t.ActivateAttract(transform, 2.0f, true);
                t.Attracted();
            }
        }
        else
        {
            if (t != null)
            {
                t.ActivateAttract(transform, 0, false);
            }
        }
    }
}
