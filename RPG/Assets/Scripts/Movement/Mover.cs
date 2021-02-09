using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        private NavMeshAgent _agent;

        private Animator _anim;


        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _anim = GetComponent<Animator>();
        }


        void Update()
        {
            UpdateAnim();
        }



        public void MoveTo(Vector3 destination)
        {
            _agent.destination = destination;
            _agent.isStopped = false;
        }

        public void Cancel()
        {
            _agent.isStopped = true;
        }

        private void UpdateAnim()
        {
            Vector3 velocity = _agent.velocity;
            // Word space change to local
            Vector3 localeVelocity = transform.InverseTransformDirection(velocity);
            // Need a Z axis, to running the animation
            float speed = localeVelocity.z;
            _anim.SetFloat("forwardSpeed", speed);
        }

        public void StartMoveAction(Vector3 dest)
        {
            GetComponent<ActionScheduler>().StartAction(this);

            MoveTo(dest);
        }

    }//class
}