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
        StartCoroutine(UpdateDistance());
    }

    IEnumerator UpdateDistance()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            distanceTravelled = (startPos.transform.position.x + this.transform.position.x);
            distanceText.text = "DISTANCE: " + distanceTravelled.ToString("0.00") + " m";
        }
    }
}
