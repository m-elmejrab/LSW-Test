using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string itemName;
    public int price;
    public Sprite sprite;
    public ItemType type;
    
    public enum ItemType
    {
        Weapon,
        Helmet
    }
}
