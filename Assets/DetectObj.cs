using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObj : MonoBehaviour
{
    private WinCheck winCheck;
    private void Start()
    {
        winCheck = FindObjectOfType<WinCheck>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Money"))
        {
            collision.gameObject.SetActive(false);
            winCheck.Check();
        }
        else if (collision.CompareTag("Sharp"))
        {
            winCheck.EndGame(true);
        }
    }
}
