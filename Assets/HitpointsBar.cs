using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitpointsBar : MonoBehaviour {

    public Hitpoint hitpointPrefab;

    public static HitpointsBar instance;
    public List<Hitpoint> hitpointList;

	// Use this for initialization
	void Start () {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Heal(Player.instance.hitpoint);
    }

    public void Damage(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Hitpoint hitpoint = hitpointList[hitpointList.Count - 1];
            hitpointList.Remove(hitpoint);
            hitpoint.Hide();
        }
    }

    public void Heal(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector2 position = new Vector2(transform.position.x + hitpointList.Count, transform.position.y);
            Hitpoint hitpoint = Instantiate<Hitpoint>(hitpointPrefab);
            hitpoint.transform.position = position;
            hitpointList.Add(hitpoint);
        }
    }
}
