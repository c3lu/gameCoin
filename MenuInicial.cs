using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInicial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        FindObjectOfType<Musicas>().TocarMusicaDeFundo(); // Este comando ir� procurar nosso  Script Musicas, o acessar� e permitir� que p�ssamos acessar o m�todo TocarMusicaDeFundo()
    }

    public void IniciarJogo()
    {
        Time.timeScale = 1f; // Essa linha de c�digo, usando o comando timeScale, ir� descongelar o game, pois atribu�mos o valor de 100% (1f ou 1 float) na velocidade do game, onde ele estava congelado.
        this.gameObject.SetActive(false); // Este comando ir� desativar a tela inical, visto o comando this.gameObject especificar o Game Object do Menu Inicial, marcando-o false

    }
    public void SairDoJogo()
    {
        Application.Quit(); // Fecha o game
        Debug.Log("Saiu do Game");
    }


}
