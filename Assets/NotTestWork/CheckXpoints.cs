using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckXpoints : MonoBehaviour
{
    //[HideInInspector]
    public List<Transform> points = new List<Transform>();
    CheckTable checkTable;
    private void Start()
    {
        checkTable = FindObjectOfType<CheckTable>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Point")
        {
            points.Add(collision.transform);
        }
        if(points.Count == 3)
        {
            checkTable.Get3X(this);
        }
    }
}
