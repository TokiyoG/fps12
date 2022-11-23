using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agentScrip : MonoBehaviour
{
    public Animator animator;
    public Transform goal;
    bool isDead = false;
    public   NavMeshAgent agent; 
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>(); 

        agent.destination = goal.position;
        if (isDead == false)
        {
            animator.SetFloat("Speed_f", agent.velocity.magnitude);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet") 

        {

            animator.SetInteger("DeathType_int", 1); 

            animator.SetBool("Death_b", true); 



            isDead = true; 

            agent.speed = 0;

        }
    }
}
