using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public Text distanceText;
    private int distanceTravelled = 0;
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
            distanceTravelled = ((int)(startPos.transform.position.x + this.transform.position.x));
            distanceText.text = "DISTANCE: " + distanceTravelled.ToString("0.00") + " m";
        }
    }
}
