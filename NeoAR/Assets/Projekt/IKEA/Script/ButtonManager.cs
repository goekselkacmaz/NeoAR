using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ButtonManager : MonoBehaviour
{
    private Button btn;
    private RawImage buttonImage;
    public float dauer;

    private int _itemId;
    private Sprite _buttonTexture;

    public int ItemId
    {
        set => _itemId = value;
        //das gleiche wie oben
        //set { _itemId = value; }
    }
    public Sprite ButtonTexture
    {
        get => _buttonTexture;
        set
        {
            _buttonTexture = value;
            buttonImage.texture = _buttonTexture.texture;
        }
    }
    public GameObject furniture;
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectObjekt);
    }

    private void SelectObjekt()
    {
        DataHandler.Instance.SetFurniture(_itemId);
       // DataHandler.Instance.selectedObject = furniture; alte
    }

    private void Update()
    {
        if (UIManager.Instance.onEntered(gameObject))
        {
            transform.DOScale(Vector3.one * 2, dauer);
            //transform.localScale = Vector3.one * 2;
        }
        else
        {
            transform.DOScale(Vector3.one, dauer);
            //transform.localScale = Vector3.one;
        }
    }
}
