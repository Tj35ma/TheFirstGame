using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfile", menuName = "ScriptableObjects/ItemProfile", order = 1)]
public class ItemProfileSO : ScriptableObject
{
    public ItemEnum itemEnum;
    public string itemName;
    public bool isStackable = false;
}