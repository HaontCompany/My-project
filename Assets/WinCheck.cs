using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WinCheck : MonoBehaviour
{
    private int colNow, colNeed;
    private TMP_Text moneyT;
    private PlayerInput playerInput;
    [SerializeField] TMP_Text resultT;
    [SerializeField] GameObject CanvasEnd;
    private void Start()
    {
        moneyT = GetComponentInChildren<TMP_Text>();
        colNeed = GameObject.FindGameObjectsWithTag("Money").Length;
        moneyT.text = colNow + "/" + colNeed;
        playerInput = FindObjectOfType<PlayerInput>();
    }
    public void Check()
    {
        colNow++;
        moneyT.text = colNow + "/" + colNeed;
        if (colNow == colNeed)
        {
            EndGame();
        }
    }
    public void EndGame(bool lose = false)
    {
        if(lose)
        resultT.text = "Lose";
        CanvasEnd.SetActive(true);
        playerInput.enabled = false;
    }
}
