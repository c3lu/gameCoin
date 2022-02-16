using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicas : MonoBehaviour
{
    public AudioSource musicaDeFundo; // tipo de vari�vel para m�sicas
    public AudioSource musicaDeGameOver;

    public void TocarMusicaDeFundo()
    {
        musicaDeFundo.Play();
    }
    public void TocarMusicaDeGameOver()
    {
        musicaDeFundo.Stop(); // para a m�sica de fundo e come�a a tocar a m�sica de Game Over.
        musicaDeGameOver.Play();
    }
    // Observa��o: N�o esquecer de atribuir o Script Musicas ao GameObject M�sicas e atribuir os GO filhos ao script no painel inspector
}
