using System;
using RPG.Movement;
using UnityEngine;
using RPG.Core;

namespace RPG.Combat

{
    public class Fighter: MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 3f;
        [SerializeField] float timeBetweenAttacks = 1f;
        Transform target;
        float timeSinceLastAttack = 0f;

        private void Update()
        {
            timeSinceLastAttack =+ Time.deltaTime;

            if (target == null) return;
            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            if(timeSinceLastAttack > timeBetweenAttacks)
            {
                GetComponent<Animator>().SetTrigger("attacking");
                timeSinceLastAttack = 0;
            }
            
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;                      
        }

        public void Cancel()
        {
            target = null;
        }


        //Animation Event.
        void Hit()
        {
            
        }    
    }
}