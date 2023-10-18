using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    [SerializeField] GameObject _transition;
    private void Awake()
    {
        _transition.SetActive(true);
    }

}
