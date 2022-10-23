using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] float speed = 5;
    private List<Vector3> posPoint = new List<Vector3>();
    private LineRenderer lineR;
    private Transform playerT;
    void Start()
    {
        lineR = FindObjectOfType<LineRenderer>();
        playerT = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        lineR.positionCount = posPoint.Count + 1;
        lineR.SetPosition(0, playerT.position);

        for (int i = 0; i < posPoint.Count; i++)
        {
            Vector3 pointpos = posPoint[i];
            lineR.SetPosition(i + 1, pointpos);
        }
        if (Input.GetMouseButtonDown(0))
        {
            posPoint.Add(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)));
        }
        if (posPoint.Count > 0)
        {

            playerT.position = Vector3.MoveTowards(playerT.position, posPoint[0], speed * Time.deltaTime);
            if (playerT.position == posPoint[0])
            {
                posPoint.RemoveAt(0);
            }
        }
    }
}
