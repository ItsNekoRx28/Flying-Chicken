using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persist : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Se reinician los valores de mejora por sesion
        PlayerPrefs.SetInt("cannon", 0);
        PlayerPrefs.SetInt("flaps", 0);
        PlayerPrefs.SetInt("fall", 0);
        PlayerPrefs.SetInt("life", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
