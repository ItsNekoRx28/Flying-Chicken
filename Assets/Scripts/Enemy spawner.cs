using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{

    public GameObject planePrefab;
    public GameObject balloonPrefab;
    public GameObject carPrefab;
    public GameObject jumpPadPrefab;
    GameObject objeto;
    float altura;
    private float spawnNext = 0;
    public float spawnRatePerMinute = 60;
    RectTransform miRectangulo;
    float altura_media;
    private bool isLaunched = false;

    // Start is called before the first frame update
    private void Start()
    {
        miRectangulo = GetComponent<RectTransform>();
        altura_media = miRectangulo.rect.yMax - miRectangulo.rect.yMin;
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
                    objeto = Random.value < 0.5 ? carPrefab : jumpPadPrefab;
                    break;
                case float n when (n > 20 && n <= 40):
                    objeto = balloonPrefab;
                    break;
                case float n when (n > 40 && n <= 60):
                    objeto = planePrefab;
                    break;
                default:
                    objeto = null;
                    break;
            }
            if (objeto == null)
            {
                return;
            }
            float alturaSpawn = Random.Range(alturaMin, alturaMax);
            Vector2 posicion = new Vector2(this.transform.position.x, alturaSpawn);
            GameObject spawned = Instantiate(objeto, posicion, Quaternion.identity);
        }


    }
}
