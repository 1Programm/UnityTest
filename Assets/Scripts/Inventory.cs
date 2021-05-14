using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] int slotCount = 15;
    [SerializeField] int rowCount = 5;

    [SerializeField] GameObject prefab;

    private IItem[] items;
    void Start()
    {
        RectTransform rT = (RectTransform)gameObject.transform;
        
        items = new IItem[slotCount];
        for (int i = 0; i<slotCount; i++)
        {
               GameObject slot = Instantiate(prefab);


            RectTransform tran = (RectTransform)slot.transform;
            tran.SetParent(gameObject.transform, false);
            tran.anchorMin = new Vector2(0,1);
            tran.anchorMax = new Vector2(0,1);
            tran.anchoredPosition = new Vector3(100 + i%rowCount* ((int)(rT.sizeDelta.x-100) / rowCount),-100 -i/rowCount*200 , 0);
            //Make spread relative to count and pixels
        }
        
    }

    public bool addItem(int slot, IItem item)
    {
        if(items[slot] == null)
        {
            items[slot] = item;
            return true;
        }
        return false;
    }
    public IItem getItem(int slot)
    {
        return items[slot];
    }
}
