using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item1", menuName ="AddItem_gkspeziell/Item")]
public class Item : ScriptableObject
{
    public float price;
    public GameObject itemPrefab;
    public Sprite ItemImage;
}
