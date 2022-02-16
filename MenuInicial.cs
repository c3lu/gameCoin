using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInicial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        FindObjectOfType<Musicas>().TocarMusicaDeFundo(); // Este comando irá procurar nosso  Script Musicas, o acessará e permitirá que póssamos acessar o método TocarMusicaDeFundo()
    }

    public void IniciarJogo()
    {
        Time.timeScale = 1f; // Essa linha de código, usando o comando timeScale, irá descongelar o game, pois atribuímos o valor de 100% (1f ou 1 float) na velocidade do game, onde ele estava congelado.
        this.gameObject.SetActive(false); // Este comando irá desativar a tela inical, visto o comando this.gameObject especificar o Game Object do Menu Inicial, marcando-o false

    }
    public void SairDoJogo()
    {
        Application.Quit(); // Fecha o game
        Debug.Log("Saiu do Game");
    }


}
