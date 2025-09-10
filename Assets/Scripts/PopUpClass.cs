using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BrunoMikoski.TextJuicer;
using TMPro;
using UnityEngine;

public class PopUpClass : MonoBehaviour
{
   
    private List<TMP_TextJuicer> _textJuicers = new List<TMP_TextJuicer>();
    private List<TMP_Text> _texts = new List<TMP_Text>();
    private CartClass _cart;
    
    public void Init(CartClass cartClass)
    {
        _cart = cartClass;
        _texts = GetComponentsInChildren<TMP_Text>().ToList();
        _textJuicers = GetComponentsInChildren<TMP_TextJuicer>().ToList();
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
        foreach (var juicer in _textJuicers)
        {
            juicer.Restart();
            juicer.Play();
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
