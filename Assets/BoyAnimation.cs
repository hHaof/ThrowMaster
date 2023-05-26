using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyAnimation : MonoBehaviour
{
    public GameManager _gm;
    private Animator boyAni;



    private void Start()
    {
        boyAni = GetComponent<Animator>();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MilkBox"))
        {
            Destroy(collision.gameObject, 0.1f);
            boyAni.SetBool("Drinking", true);

            _gm.GetComponent<GameManager>().WrapWin();
        }
    }
}
