using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{
    public int cantidadInicial;
    public GameObject planePrefab;
    public GameObject balloonPrefab;
    public GameObject carPrefab;
    public GameObject jumpPadPrefab;
    public GameObject monedaPrefab;
    GameObject objeto;
    float altura;
    private float spawnNext = 0;
    public float spawnRatePerMinute = 60;
    RectTransform miRectangulo;
    float altura_media;
    private bool isLaunched = false;
    float alturaSpawn;
    public static List<GameObject> poolPlane = new List<GameObject>();
    public static List<GameObject> poolBalloon = new List<GameObject>();
    public static List<GameObject> poolCar = new List<GameObject>();
    public static List<GameObject> poolJumpPad = new List<GameObject>();
    public static List<GameObject> poolMoneda = new List<GameObject>();


    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Spawn Cosas");
        miRectangulo = GetComponent<RectTransform>();
        altura_media = miRectangulo.rect.yMax - miRectangulo.rect.yMin;
        for (int i = 0; i < cantidadInicial; i++)
        {
            GameObject plane = Instantiate(planePrefab);
            GameObject balloon = Instantiate(balloonPrefab);
            GameObject car = Instantiate(carPrefab);
            GameObject jumpPad = Instantiate(jumpPadPrefab);
            GameObject moneda = Instantiate(monedaPrefab);
            plane.SetActive(false);
            balloon.SetActive(false);
            car.SetActive(false);
            jumpPad.SetActive(false);
            moneda.SetActive(false);
            poolPlane.Add(plane);
            poolBalloon.Add(balloon);
            poolCar.Add(car);
            poolJumpPad.Add(jumpPad);
            poolMoneda.Add(moneda);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLaunched && Input.GetKeyDown(KeyCode.Space))
        {
            isLaunched = true;
        }
        if (Time.time > spawnNext && isLaunched)
        {
            spawnNext = Time.time+60/spawnRatePerMinute;
            
            altura = this.transform.position.y; // La altura del objeto
            float alturaMin = altura_media + altura;
            float alturaMax = altura-altura_media;

            switch (altura)
            {
                case float n when (n <= 20):
                    
                    if (Random.value < 0.5)
                    {
                        objeto = poolCar.Find(b => !b.activeInHierarchy);
                        alturaSpawn = -3;
                    }
                    else
                    {
                        objeto = poolJumpPad.Find(b => !b.activeInHierarchy);
                    }
                    break;
                case float n when (n > 20 && n <= 40):
                    objeto = poolBalloon.Find(b => !b.activeInHierarchy);
                    break;
                case float n when (n > 40):
                    objeto = poolPlane.Find(b => !b.activeInHierarchy);
                    break;
                default:
                    objeto = null;
                    break;
            }
            if (objeto == null)
            {
                return;
            }
            if (alturaSpawn==0)
            {
                alturaSpawn = Random.Range(alturaMin, alturaMax);
            }

            Vector2 posicion = new Vector2(this.transform.position.x, alturaSpawn);
            Vector2 posicionMoneda = new Vector2(this.transform.position.x, alturaSpawn+4);
            objeto.transform.position = posicion;
            GameObject moneda = poolMoneda.Find(b => !b.activeInHierarchy);
            moneda.transform.position = posicionMoneda;
            moneda.SetActive(true);
            objeto.SetActive(true);
            alturaSpawn = 0;
            //GameObject spawned = Instantiate(objeto, posicion, Quaternion.identity); 
            //GameObject monedaSpawn = Instantiate(monedaPrefab, posicionMoneda, Quaternion.identity);
        }


    }
}
