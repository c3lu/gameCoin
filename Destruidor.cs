using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruidor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) // script para destruir os objetos que toquem no Trigger ativado do Destruidor
    {
        Destroy(other.gameObject); // other quer dizer todos os objetos que tocarem no Destruidor (o objeto desta classe) ir�o ser destruidos.
    }
}
// Obs.: Verifique se a caixinha "Is Trigger" est� marcada, sen�o n�o funcionar�