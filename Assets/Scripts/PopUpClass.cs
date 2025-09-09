using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PopUpClass : MonoBehaviour
{
   
    private List<TMP_Text> _texts = new List<TMP_Text>();
    
    public void Init()
    {
        _texts = GetComponentsInChildren<TMP_Text>().ToList();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
