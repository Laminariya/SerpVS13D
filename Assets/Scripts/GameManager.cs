using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public float Duration;
    public float Delay;
    
    public Button b_Left;
    public Button b_Right;
    public List<RectTransform> MenuItems = new List<RectTransform>();
    public RectTransform MenuParent;
    public float SpeedMenu = 1f;

    private Vector2 _minVector2;
    private Vector2 _maxVector2;
    private int _activeItem = 1;
    private List<RectTransform> _items = new List<RectTransform>();

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    void Start()
    {
        _minVector2 = new Vector2(0, MenuItems[0].offsetMin.y);
        _maxVector2 = new Vector2(0, MenuItems[0].offsetMax.y);
        b_Left.onClick.AddListener(OnLeftClick);
        b_Right.onClick.AddListener(OnRightClick);
        InitMenu();
    }
    
    void Update()
    {
        
    }

    private void InitMenu()
    {
        for (int i = 0; i < MenuItems.Count; i++)
        {
            MenuItems[i].offsetMin =
                new Vector2(25f + i * 125f, MenuItems[i].offsetMin.y);
            MenuItems[i].offsetMax =
                new Vector2(125f + i * 125f, MenuItems[i].offsetMax.y);
            Debug.Log(MenuItems[i].offsetMin + " " + MenuItems[i].offsetMax);
            _items.Add(MenuItems[i]);
        }
        
    }

    private void OnLeftClick()
    {
        b_Left.enabled = false;
        b_Right.enabled = false;
        StartCoroutine(MoveLeft());
    }

    private void OnRightClick()
    {
        b_Left.enabled = false;
        b_Right.enabled = false;
        StartCoroutine(MoveRight());
    }

    IEnumerator MoveLeft()
    {
        float distance = 125f;
        _items[1].GetChild(0).localScale = Vector3.one;
        float startX = _items[0].offsetMin.x;
        while (true)
        {
            var delta = SpeedMenu * Time.deltaTime;
            distance -= delta;
            if (distance < 0)
            {
                for (int i = 0; i < _items.Count; i++)
                {
                    _minVector2.x = startX - 125f + i * 125f;
                    _maxVector2.x = startX - 25f + i * 125f;
                    _items[i].offsetMin = _minVector2;
                    _items[i].offsetMax = _maxVector2;
                }
                _minVector2.x = startX + (_items.Count-1) * 125f;
                _maxVector2.x = startX +100 + (_items.Count-1) * 125f;
                _items[0].offsetMin = _minVector2;
                _items[0].offsetMax = _maxVector2;
                RectTransform image = _items[0];
                _items.RemoveAt(0);
                _items.Add(image);
                _items[1].GetChild(0).localScale *= 1.2f;
                FinishMoveMenu();
                yield break;
            }
            for (int i = 0; i < MenuItems.Count; i++)
            {
                _minVector2 = _items[i].offsetMin;
                _maxVector2 = _items[i].offsetMax;
                _minVector2.x -= delta;
                _maxVector2.x -= delta;
                _items[i].offsetMin = _minVector2;
                _items[i].offsetMax = _maxVector2;
            }
            yield return null;
        }
    }
    
    IEnumerator MoveRight()
    {
        float distance = 125f;
        float startX = _items[0].offsetMin.x;
        _items[1].GetChild(0).localScale = Vector3.one;
        
        _minVector2.x = startX - 125f;
        _maxVector2.x = startX -25f;
        _items[5].offsetMin = _minVector2;
        _items[5].offsetMax = _maxVector2;
        RectTransform image = _items[5];
        _items.RemoveAt(5);
        _items.Insert(0, image);
        while (true)
        {
            var delta = SpeedMenu * Time.deltaTime;
            distance -= delta;
            if (distance < 0)
            {
                for (int i = 0; i < _items.Count; i++)
                {
                    _minVector2.x = startX + i * 125f;
                    _maxVector2.x = startX + 100f + i * 125f;
                    _items[i].offsetMin = _minVector2;
                    _items[i].offsetMax = _maxVector2;
                }

                _items[1].GetChild(0).localScale *= 1.2f;
                FinishMoveMenu();
                yield break;
            }
            for (int i = 0; i < MenuItems.Count; i++)
            {
                _minVector2 = _items[i].offsetMin;
                _maxVector2 = _items[i].offsetMax;
                _minVector2.x += delta;
                _maxVector2.x += delta;
                _items[i].offsetMin = _minVector2;
                _items[i].offsetMax = _maxVector2;
            }
            yield return null;
        }
    }

    private void FinishMoveMenu()
    {
        b_Left.enabled = true;
        b_Right.enabled = true;
    }
}
