using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bag : MonoBehaviour {

    public GameObject slot;
    public GameObject item;

    ItemDataBase itemdatabase;

    public List<GameObject> slots = new List<GameObject>();
    public List<Item> items = new List<Item>();

    GameObject slotPanel;
	// Use this for initialization
	void Start () {
        itemdatabase = GetComponent<ItemDataBase>();
        slotPanel = GameObject.Find("Slot Panel");

        for (int i = 0; i < 16; i++)
        {
            slots.Add(Instantiate(slot));
            slots[i].transform.SetParent(slotPanel.transform);
            items.Add(new Item());
        }
        AddItem(0);
        AddItem(1);


    }
	
    public void AddItem(int _id)
    {
        Item itemToAdd = itemdatabase.FetchItemByID(_id);
        
        for (int i = 0; i < items.Count; i++)
        {
            if(items[i].ID == -1)
            {
                items[i] = itemToAdd;
                GameObject itemObj = Instantiate(item);
                itemObj.transform.SetParent(slots[i].transform);
                itemObj.transform.position = Vector2.zero;
                itemObj.name = itemToAdd.Title;
                itemObj.GetComponent<Image>().sprite = itemToAdd.sprite;
                break;
            }
        }

    }
	
}
