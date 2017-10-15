using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item
{
    None, Apple, Key, Cheese, Health
}

public class ItemDisplay : MonoBehaviour {

    public Sprite selected;
    public Sprite unselected;
    public GameObject itemObject;

    public Sprite keySprite;
    public Sprite cheeseSprite;
    public Sprite healthSprite;
    public Sprite appleSprite;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer itemRenderer;
    public Item item;

    public void SetItem(Item item)
    {
        switch (item) {
            case Item.None:
                itemRenderer.sprite = null;
                break;
            case Item.Apple:
                itemRenderer.sprite = appleSprite;
                break;
            case Item.Cheese:
                itemRenderer.sprite = cheeseSprite;
                break;
            case Item.Health:
                itemRenderer.sprite = healthSprite;
                break;
            case Item.Key:
                itemRenderer.sprite = keySprite;
                break;
        }
        this.item = item;
    }

    private void UseApple()
    {

    }

    private void UseCheese()
    {

    }

    private void UseHealth()
    {
        SetItem(Item.None);
    }

    private void UseKeys()
    {
        SetItem(Item.None);
    }

    public void Use()
    {
        switch (item)
        {
            case Item.Apple:
                UseApple();
                break;
            case Item.Cheese:
                UseCheese();
                break;
            case Item.Health:
                UseHealth();
                break;
            case Item.Key:
                UseKeys();
                break;
        }
    }

    public void Select()
    {
        spriteRenderer.sprite = selected;
    }

    public void Deselect()
    {
        spriteRenderer.sprite = unselected;
    }

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        itemRenderer = itemObject.GetComponent<SpriteRenderer>();
        SetItem(Item.None);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
