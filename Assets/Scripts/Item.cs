using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string itemName;
    public int price;
    public Sprite picture;
    public ItemType type;
    
    public enum ItemType
    {
        Weapon,
        Helmet
    }
}
