using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // assim como importamos a biblioteca de UI no outro Script, aqui importamos a biblioteca para a Unity reconhecer os carretgamentos de cena, logo dos botões.

public class MenuDeGameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Musicas>().TocarMusicaDeGameOver(); // Este comando irá procurar nosso  Script Musicas, o acessará e permitirá que póssamos acessar o método TocarMusicaDeGameOver()
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ReiniciarPartida()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Este código irá carregar a cena atual do nosso game.
    }

    public void SairDoJogo()
    {
        Application.Quit(); // Fecha o game
        Debug.Log("Saiu do Jogo"); //teste se saiu do game
    }

}

//Obs: Temos que add o Script MenuDeGameOver ao Game Object "Painel De game Object". Após isso, vamos em Button, na aba Inspector e, em On Click, arrastamos o Game Object "Painel de Game Over" para None (Object), sendo feito para cada Game Object criado para os botões, como Reiniciar Botão e Sair Botão.