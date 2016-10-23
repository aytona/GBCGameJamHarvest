using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneTest : MonoBehaviour {
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * 10.0f * Time.deltaTime);
        }

        if(transform.position.z > 12.0f)
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        }
	}
}
