using RPG.Movement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control

{
    public class PlayerController : MonoBehaviour
    {

        private void Update()
        {
            InteractCombat();
            InteractMovement();
        }

        private void InteractCombat()
        {
            throw new NotImplementedException();
        }

        private void InteractMovement()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
        }

        private void MoveToCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);
            if (hasHit)
            {
                GetComponent<Mover>().MoveTo(hit.point);
            }

        }
    }

}