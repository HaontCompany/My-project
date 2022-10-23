using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckTable : MonoBehaviour
{
    [SerializeField] Transform XposT, YposT;
    [SerializeField] GameObject CanvasV;

    float timeForUI = 1f, alpha = 1;
    private bool endGame, victory;
    private Color col;
    private List<SpriteRenderer> sprites = new List<SpriteRenderer>();

    public void ChTable(Vector2 pos)
    {
        XposT.position = new Vector3(pos.x, XposT.position.y, .1f);
        YposT.position = new Vector3(YposT.position.x, pos.y, .1f);
        endGame = true;
        PlayerPrefs.SetString("ParentName", "");
        PlayerPrefs.Save();
    }
    public void Get3X(CheckXpoints checks)
    {
        foreach (var point in checks.points)
        {
            sprites.Add(point.GetComponent<SpriteRenderer>());
        }
        col = sprites[0].color;
        victory = true;
    }
    void Update()
    {
        if (endGame)
        {
            timeForUI -= Time.deltaTime;
            if (timeForUI < 0)
            {
                if (!victory)
                    CanvasV.GetComponentInChildren<Text>().text = "ÎØÈÁÊÀ";
                    CanvasV.SetActive(true);
                endGame = false;
            }
            if (alpha > 0)
            {
                alpha -= Time.deltaTime * 5;
                foreach (var sprite in sprites)
                {
                    col.a = alpha;
                    sprite.color = col;
                }
            }
        }
    }
}
