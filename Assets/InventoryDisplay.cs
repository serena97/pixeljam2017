using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour {

    public static InventoryDisplay instance;
    public KeyCode nextItem = KeyCode.V;
    public KeyCode previousItem = KeyCode.C;
    public ItemDisplay[] itemDisplays;

    private int selectedIndex = 0;

	// Use this for initialization
	void Start () {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
        
        itemDisplays[selectedIndex].Select();
    }

    private void NextItem()
    {
        itemDisplays[selectedIndex].Deselect();

        if(selectedIndex == itemDisplays.Length - 1)
        {
            selectedIndex = 0;
        }
        else
        {
            selectedIndex++;
        }

        itemDisplays[selectedIndex].Select();
    }

    private void PreviousItem()
    {
        itemDisplays[selectedIndex].Deselect();

        if (selectedIndex == 0)
        {
            selectedIndex = itemDisplays.Length - 1;
        }
        else
        {
            selectedIndex--;
        }

        itemDisplays[selectedIndex].Select();
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(nextItem)) {
            NextItem();
        }
        else if(Input.GetKeyDown(previousItem)) {
            PreviousItem();
        }
	}

    public bool PickupItem(Item item)
    {
        foreach(ItemDisplay itemDisplay in itemDisplays)
        {
            if(itemDisplay.item == Item.None)
            {
                itemDisplay.SetItem(item);
                return true;
            }
        }
        return false;
    }
}
