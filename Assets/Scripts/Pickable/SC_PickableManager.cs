using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PACMAN
{
    public class SC_PickableManager : MonoBehaviour
    {
        List<SC_Pickable> _pickableList = new List<SC_Pickable>();

        private void Start()
        {
            InitPickableList();
        }
        void InitPickableList()
        {
            SC_Pickable[] pickableObjects = FindObjectsOfType<SC_Pickable>();
            for (int i = 0; i < pickableObjects.Length; i++)
            {
                _pickableList.Add(pickableObjects[i]);
                pickableObjects[i].OnPicked += OnPickablePicked;
            }
        }

        void OnPickablePicked(SC_Pickable pickable)
        {
            _pickableList.Remove(pickable);
            if (_pickableList.Count <= 0)
            {
                Debug.Log("Win");
            }
        }
    }
}
