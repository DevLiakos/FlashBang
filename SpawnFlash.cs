using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlash : MonoBehaviour
{
    public GameObject Flash;

    private void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            Instantiate(Flash, transform);
        }
    }
}
