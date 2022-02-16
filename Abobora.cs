using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abobora : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) // Mesma coisa que fiz com a moeda, variável padrão "other" que irá caracterizar a abóborá com o colisor
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Jogador>().GameOver();
            Destroy(this.gameObject, 0.08f);
        }
    } 
   
}
