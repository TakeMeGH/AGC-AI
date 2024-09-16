using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PACMAN
{
    public class SC_Pickable : MonoBehaviour
    {

        public Enum_PickableType PickableType;
        public UnityAction<SC_Pickable> OnPicked;

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OnPicked.Invoke(this);
                Destroy(gameObject);
            }
        }
    }
}
