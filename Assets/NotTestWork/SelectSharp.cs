using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SelectSharp : MonoBehaviour
{
    //[RequireComponent(typeof(PolygonCollider2D))]
    private ChangeSlotMain changeSlotMain;
    private SpriteRenderer sprite;
    private Color colorS;
    private void Awake()
    {
        changeSlotMain = FindObjectOfType<ChangeSlotMain>();
        sprite = GetComponent<SpriteRenderer>();
        colorS = sprite.color;

        if (PlayerPrefs.HasKey("ParentName"))
        {
            string parentName = PlayerPrefs.GetString("ParentName");
            if (parentName != "")
            {
                Transform parent = GameObject.FindGameObjectWithTag("Game").transform.Find(parentName);
                transform.parent = parent;
                transform.localPosition = new Vector3(0, 0, -.1f);
            }
        }
    }
    private void OnMouseDown()
    {
        if (changeSlotMain.enabled)
        {
            changeSlotMain.GetSprite(transform);
            colorS.a = .5f;
            sprite.color = colorS;
        }
    }
    private void OnMouseUp()
    {
        if (changeSlotMain.enabled)
        {
            colorS.a = 1f;
            sprite.color = colorS;
            changeSlotMain.ChangePos();
        }
    }
}
