using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PACMAN
{
    public class SC_Pickable : MonoBehaviour
    {

        [SerializeField] Enum_PickableType _pickableType;
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
