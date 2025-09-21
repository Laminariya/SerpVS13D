using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPanel : MonoBehaviour
{

    public Button b_Left;
    public Button b_Right;
    
    public List<Sprite> sprites = new List<Sprite>();
    
    public Image image;
    
    private int _currentSprite;
    
    void Start()
    {
        b_Left.onClick.AddListener(OnLeft);
        b_Right.onClick.AddListener(OnRight);
        image.sprite = sprites[0];
    }

    private void OnRight()
    {
        _currentSprite++;
        if(_currentSprite >= sprites.Count)
            _currentSprite = 0;
        image.sprite = sprites[_currentSprite];
    }

    private void OnLeft()
    {
        _currentSprite--;
        if (_currentSprite < 0)
            _currentSprite = sprites.Count - 1;
        image.sprite = sprites[_currentSprite];
    }


}
