﻿using Consts;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField] private List<GameObject> _itemList = new();

    [HideInInspector] private StealthItem _stealth = default;
    [HideInInspector] private HealItem _heal = default;
    [HideInInspector] private StatusUpItem _status = default;

    private ItemType _type = ItemType.DEFAULT;
    private static ItemBox _instance = default;

    public List<GameObject> ItemList { get => _itemList; set => _itemList = value; }
    public ItemType Type => _type;
    public StealthItem Stealth => _stealth;
    public HealItem Heal => _heal;
    public StatusUpItem Status => _status;

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        //テスト用(アイテム削除)
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (_itemList?.Count > 0)
                DisposeToList(_itemList[0]);
        }
    }

    public static void AddToList(GameObject item)
    {
        if (_instance.ItemList.Count <= Define.ITEM_LIST_LIMIT)
        {
            _instance.ItemList.Add(item);
            item.SetActive(false);
            Debug.Log($"{item.name} をアイテムボックスに追加しました。");
        }
        else
        {
            Debug.Log("リストが上限に達しているため、アイテムを追加できません。");
        }
    }

    public static void DisposeToList(GameObject item)
    {
        _instance.ItemList.Remove(item);
        Debug.Log($"{item.name} をアイテムボックスから削除しました。");
    }

    /// <summary>
    /// UIでアイテムを選択したときに実行する
    /// </summary>
    /// <param name="item"> アイテムの種類 </param>
    public void UseItem(ItemType item)
    {
        //アイテムを使うとき、以下の関数を呼び出す(テスト)
        switch (item)
        {
            case ItemType.STEALTH:
                _stealth.UseItem(gameObject);
                break;
            case ItemType.HEAL:
                _heal.UseItem(gameObject);
                break;
            case ItemType.STATUSUP:
                _status.UseItem(gameObject);
                break;
        }
    }

    public static void UseItem(GameObject item)
    {
        _instance.ItemList.Remove(item);
        Debug.Log($"{item.name} を使用し、アイテムボックスから消費します。");
    }
}
