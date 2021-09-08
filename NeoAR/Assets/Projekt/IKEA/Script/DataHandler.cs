using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    private GameObject selectedObject;

    //public GameObject furniture;

    [SerializeField] private ButtonManager buttonPrefab;
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private List<Item> items;

    private int current_id = 0;
    
    private static DataHandler instance;
    public static DataHandler Instance
    {
      get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataHandler>();
            }
            return instance;
        }
    }

    void LoadItems()
    {
        var items_obj = Resources.LoadAll("Items", typeof(Item));
        foreach (var item in items_obj)
        {
            items.Add(item as Item);
        }
    }

    void Start()
    {
        // Disable screen dimming
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        LoadItems();
        CreateButtons();
    }


    void CreateButtons()
    {
        foreach (Item item in items)
        {
            ButtonManager b = Instantiate(buttonPrefab, buttonContainer.transform);
            b.ItemId = current_id;
            b.ButtonTexture = item.ItemImage;
            current_id++;
        }
    }

    public void SetFurniture(int id)
    {
        selectedObject = items[id].itemPrefab;
    }

    public GameObject GetSelectedObject()
    {
        return selectedObject;
    }

   
}
