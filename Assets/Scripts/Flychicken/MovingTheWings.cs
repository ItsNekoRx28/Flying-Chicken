using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovingTheWings : MonoBehaviour
{
    private int n = 0;
    Vector3 direction;
    private Rigidbody2D _rigidbody;
    public float up = 5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && n++!=0)
        {
           _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.velocity = transform.up * up * Time.deltaTime;
        }
    }
}
