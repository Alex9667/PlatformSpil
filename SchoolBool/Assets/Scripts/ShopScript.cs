using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public GameObject ShopMenu;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!ShopMenu.activeSelf)
            {
                ShopMenu.SetActive(true);
                Cursor.visible = true;
            }
        }

    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (ShopMenu.activeSelf)
            {
                ShopMenu.SetActive(false);
                Cursor.visible = false;
            }
        }
    }
}
