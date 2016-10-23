using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fuel : MonoBehaviour {

    float maxFuel = 1.0f;
    public float currentFuel;
    public Image healthbar;
	// Use this for initialization
	void Start () {
        currentFuel = maxFuel;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void UseFuel()
    {
        currentFuel -= currentFuel * 0.001f;
        healthbar.fillAmount = currentFuel;
    }

    public void AddFuel(float fuelAmmount)
    {
        currentFuel += fuelAmmount;
        if(currentFuel > maxFuel)
        {
            currentFuel = maxFuel;
        }
        healthbar.fillAmount = currentFuel;
    }
}
