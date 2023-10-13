using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float ObjectLifeTime;

    private void Start()
    {
        Destroy(gameObject, ObjectLifeTime);
    }

    //IEnumerator DestoryAfter(float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    g
    //}
}
