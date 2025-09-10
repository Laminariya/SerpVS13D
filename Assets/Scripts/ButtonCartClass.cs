using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCartClass : MonoBehaviour
{

    public CartClass Cart;

    public void Show()
    {
        if(GameManager.instance.CurrentCart!=null)
            GameManager.instance.CurrentCart.Hide();
        Cart.Show();
    }


}
