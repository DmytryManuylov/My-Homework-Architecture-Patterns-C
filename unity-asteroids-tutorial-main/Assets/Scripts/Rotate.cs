using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] 
    private int rotationSpeed;

    [SerializeField]
    private Vector3 rotationOffset;

    private void Update()
    {
        Rotator();
    }
    public void Rotator()
    {
        transform.Rotate(rotationOffset * Time.deltaTime * rotationSpeed);
    }
}

