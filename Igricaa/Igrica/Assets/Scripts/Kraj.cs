using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Kraj : MonoBehaviour {

    public int Lives = 3;
    public Text zivoti;
    
    // Use this for initialization
    void Start () {
	
	}
   
	void OnTriggerEnter(Collider other)
    {
        
        if (Lives == 0)
        {
            Debug.Log("Gotovo");
        }
        else Lives -= 1;
        zivoti.text = "Zivoti: \n" + Lives;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
