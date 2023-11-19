using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public Text distanceText;
    private float distanceTravelled = 0f;
    public GameObject startPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelled = (startPos.transform.position.x + this.transform.position.x);
        distanceText.text = "DISTANCE: " + distanceTravelled.ToString("0.00") + " m";
    }
}
