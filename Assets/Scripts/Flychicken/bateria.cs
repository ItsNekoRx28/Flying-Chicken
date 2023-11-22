using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bateria : MonoBehaviour
{

    private Animator animator;
    private int vuelo;
    public MovingTheWings A;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        A= FindAnyObjectByType<MovingTheWings>();
        A.getNumberOfWings();
        
        if (A.getNumberOfWings() < 14)
        {
            animator.SetBool("barraa5", true);
        }
        if (A.getNumberOfWings() < 11)
        {
            animator.SetBool("barraa4", true);
        }
        if (A.getNumberOfWings() < 8)
        {
            animator.SetBool("barraa3", true);
        }
        if (A.getNumberOfWings() < 5)
        {
            animator.SetBool("barraa2", true);
        }
        if (A.getNumberOfWings() < 2)
        {
            animator.SetBool("barraa1", true);
        }

    }
}
