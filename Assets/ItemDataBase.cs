using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ItemDataBase : MonoBehaviour {
    private JsonData itemdata;
    private List<Item> database = new List<Item>();
	// Use this for initialization
	void Start () {
        itemdata = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/ItemBase/items.json"));

        ConstructItemDatabase();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ConstructItemDatabase()
    {
        for (int i = 0; i < itemdata.Count; i++)
        {
            database.Add(new Item((int)itemdata[i]["id"], itemdata[i]["title"].ToString(), (int)itemdata[i]["value"], itemdata[i]["description"].ToString(), itemdata[i]["slug"].ToString()));
        }
    }

    public Item FetchItemByID(int _id)
    {
        for (int i = 0; i < database.Count; i++)
        {
            if(_id == database[i].ID)
            {
                return database[i];
            }
        }
        return null;
    }
}

public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public string Description { get; set; }
    public Sprite sprite { get; set; }

    public Item(int _id, string _title, int _value, string _description, string _slug)
    {
        this.ID = _id;
        this.Title = _title;
        this.Value = _value;
        this.Description = _description;
        this.sprite = Resources.Load<Sprite>("Items/" + _slug);
    }

    public Item()
    {
        this.ID = -1;
    }
}