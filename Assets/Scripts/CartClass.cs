using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BrunoMikoski.TextJuicer;
using BrunoMikoski.TextJuicer.Modifiers;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CartClass : MonoBehaviour
{

    public Image Image;
    public List<PopUpClass> PopUps = new List<PopUpClass>();
    
    private List<TMP_TextJuicer> texts = new List<TMP_TextJuicer>();
    private List<Button> buttons = new List<Button>();
    
    void Start()
    {
        texts = GetComponentsInChildren<TMP_TextJuicer>(true).ToList();
        buttons = GetComponentsInChildren<Button>(true).ToList();

        for (int i = 0; i < PopUps.Count; i++)
        {
            PopUps[i].Init(this);
            buttons[i].onClick.AddListener(PopUps[i].Show);
        }
        Show();
    }

    public void HideAllPopap()
    {
        for (int i = 0; i < PopUps.Count; i++)
        {
            PopUps[i].Hide();
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        GameManager.instance.CurrentCart = this;
        gameObject.SetActive(true);
        Image.color = Color.clear;
        Image.DOColor(Color.white, 0.5f);
        
        StartCoroutine(AnimButtons());
    }

    IEnumerator AnimButtons()
    {
        foreach (var text in texts) 
        {
            //text.GetComponent<TMP_Text>().color = Color.clear;
            //text.GetComponent<TextJuicerGradientModifier>().ModifyCharacter();
        }
        foreach (var text in texts) 
        {
            text.Play();
            yield return new WaitForSeconds(0.1f);
        }
        while (true)
        {
            foreach (var button in buttons)
            {
                button.transform.DOPunchScale(Vector3.one*0.2f, 1f, 0, 1f);
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
