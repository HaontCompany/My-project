using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSlotMain : MonoBehaviour
{
    private CheckTable checkTable;

    private SpriteRenderer sptiteR;
    private Transform sptiteT;
    private List<Transform> slots = new List<Transform>();
    private void Start()
    {
        sptiteR = GetComponent<SpriteRenderer>();
        checkTable = FindObjectOfType<CheckTable>();
    }
    public void GetSprite(Transform spritet = null)
    {
        sptiteT = spritet;
        sptiteR.enabled = true;
    }
    public void Update()
    {
        if (sptiteT)
        {
            Vector2 newPosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            transform.position = newPosition;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Slot"))
        {
            if (collision.transform.childCount == 0)
            {
                slots.Add(collision.transform);
                //Debug.Log(collision.name);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Slot"))
        {
            slots.Remove(collision.transform);
        }
    }
    public void ChangePos()
    {
        sptiteR.enabled = false;
        if (slots.Count > 0)
        {
            float distmin = 10f;
            Transform newParent = null;
            foreach (var slot in slots)
            {
                if (slot.childCount == 0)
                {
                    float distnew = Vector2.Distance(transform.position, slot.position);
                    //Debug.Log(slot.name + " dist " + distnew);
                    if (distnew < distmin)
                    {
                        distmin = distnew;
                        newParent = slot;
                    }
                }
            }
            PlayerPrefs.SetString("ParentName", newParent.name);
            PlayerPrefs.Save();

            if (newParent.parent.tag == "Table")
            {
                checkTable.ChTable(newParent.position);
                enabled = false;
            }
            sptiteT.parent = newParent;
            sptiteT.localPosition = new Vector3(0, 0, -.1f);

            //На один квадрат
            
        }
        transform.position = Vector3.zero;
        slots.Clear();
        sptiteT = null;
    }
}
/* PlayerPrefs.SetInt("SavedInteger", intToSave);
  PlayerPrefs.SetFloat("SavedFloat", floatToSave);
  PlayerPrefs.SetString("SavedString", stringToSave);
  PlayerPrefs.Save();

 if (PlayerPrefs.HasKey("SavedInteger"))
  {
    intToSave = PlayerPrefs.GetInt("SavedInteger");
    floatToSave = PlayerPrefs.GetFloat("SavedFloat");
    stringToSave = PlayerPrefs.GetString("SavedString");
    Debug.Log("Game data loaded!");
  }
 */