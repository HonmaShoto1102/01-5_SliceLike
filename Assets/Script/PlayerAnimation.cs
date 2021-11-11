using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    public Rigidbody rbKnife;           //Å©óÕÇâ¡Ç¶ÇÈëŒè€

    public Animator animator;
    private bool attack_change = false;
    private bool Idle_change = false;


    // Start is called before the first frame update
    void Start()
    {
       // this.animator = GetComponent<Animator>();
       
    }
    private void FixedUpdate()
    {
        //rbKnife.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (Idle_change == false) animator.SetTrigger("AttackTrigger");
            Idle_change = true;
            attack_change = !attack_change;
        }

        if (Idle_change == true)
        {
            if (attack_change == true)
            {
                animator.SetBool("AttackBool", true);
                Debug.Log("AttackÅF2");
            }
            if (attack_change == false)
            {
                animator.SetBool("AttackBool", false);
                Debug.Log("AttackÅF1");
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.tag == "Block" || collision.tag == "Goal")
        {
            Debug.Log("animation:BlockÇ∆ê⁄êG");
            //Ç±Ç±Ç≈äÆëSÇ…å≈íËÇ≥ÇπÇÈ
            rbKnife.isKinematic = true;
            attack_change = false;
            animator.SetBool("IdleBool", true);
        }



    }

}
