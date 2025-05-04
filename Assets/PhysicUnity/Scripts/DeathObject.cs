using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathObject : MonoBehaviour
{
    
    public GameManager GameOver;
    private string _looseMassage = "Вы проиграли";


    private void OnCollisionEnter(Collision collision)
    {
        GameOver.GameOver();
        Debug.Log(_looseMassage);
    }
}
