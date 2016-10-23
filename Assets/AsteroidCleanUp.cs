using UnityEngine;
using System.Collections;

public class AsteroidCleanUp : MonoBehaviour {
    public float m_maxDistanceToPlayer = 75.0f;
    private PlayerRadius m_player;
	// Use this for initialization
	void Start () {
        m_player = FindObjectOfType<PlayerRadius>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Vector3.Distance(transform.position, m_player.transform.position) > m_maxDistanceToPlayer)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, 5 * Time.deltaTime);
            if (transform.localScale.x < 3)
                Destroy(this.gameObject);
        }
	}
}
