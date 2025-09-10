using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PopUpClass : MonoBehaviour
{
   
    private List<TMP_Text> _texts = new List<TMP_Text>();
    private CartClass _cart;
    
    public void Init(CartClass cartClass)
    {
        _cart = cartClass;
        _texts = GetComponentsInChildren<TMP_Text>().ToList();
    }

    public void Show()
    {
        if (gameObject.activeSelf)
        {
            Hide();
            return;
        }

        _cart.HideAllPopap();
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
