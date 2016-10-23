using UnityEngine;
using System.Collections;

public class AsteroidPopIn : MonoBehaviour {
    public float max;

	// Update is called once per frame
	void Update () {
	    if(transform.localScale.x < max)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * max, 0.7f * Time.deltaTime);
        }
	}
}
