using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public List<Item> items = new List<Item>();
    public int slotCnt = 20;

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;
    void Start()
    
    {
        
    }

   public bool AddItem(Item _item)
    {
        if(items.Count < slotCnt)
        {
            items.Add(_item);
            if(onChangeItem !=null)
            onChangeItem.Invoke();
            return true;
        }
        return false;
    }
    public void RemoveItem(int _index) {
        items.RemoveAt(_index);
        onChangeItem.Invoke();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FieldItem")) {
            Debug.Log("enter");
            FieldItems fieldItems = collision.GetComponent<FieldItems>();
            if (AddItem(fieldItems.GetItem()))
                fieldItems.DestroyItem();
        }
    }
}
