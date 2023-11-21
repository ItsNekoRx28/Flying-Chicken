using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pollo;
    public float distancia = 5.0f;


    // Update is called once per frame
    void Update()
    {
        Vector3 posicionObjetivo = pollo.transform.position;
        Vector3 direccion = (transform.position - posicionObjetivo).normalized;
        transform.position = posicionObjetivo + direccion * distancia;
    }
}
