using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bateria : MonoBehaviour
{

    private Animator animator;
    public MovingTheWings A;

    private int nFlaps;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        nFlaps = A.getNumberOfWings();
    }

    // Update is called once per frame
    void Update()
    {
        A = FindAnyObjectByType<MovingTheWings>();
        
        if ((double)A.getNumberOfWings() < nFlaps * 0.75)
        {
            animator.SetBool("barraa5", true);
        }
        if ((double)A.getNumberOfWings() < nFlaps * 0.5)
        {
            animator.SetBool("barraa4", true);
        }
        if ((double)A.getNumberOfWings() < nFlaps * 0.25)
        {
            animator.SetBool("barraa3", true);
        }
        if ((double)A.getNumberOfWings() < nFlaps * 0.15)
        {
            animator.SetBool("barraa2", true);
        }
        if ((double)A.getNumberOfWings() < 2)
        {
            animator.SetBool("barraa1", true);
        }

    }
}
