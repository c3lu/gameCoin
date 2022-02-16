using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicas : MonoBehaviour
{
    public AudioSource musicaDeFundo; // tipo de variável para músicas
    public AudioSource musicaDeGameOver;

    public void TocarMusicaDeFundo()
    {
        musicaDeFundo.Play();
    }
    public void TocarMusicaDeGameOver()
    {
        musicaDeFundo.Stop(); // para a música de fundo e começa a tocar a música de Game Over.
        musicaDeGameOver.Play();
    }
    // Observação: Não esquecer de atribuir o Script Musicas ao GameObject Músicas e atribuir os GO filhos ao script no painel inspector
}
