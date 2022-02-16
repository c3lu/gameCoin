using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorAleatorio : MonoBehaviour
{
    public GameObject[] objetosParaSpawnar;
    public Transform[] pontosDeSpawn;

    public float tempoEntreOsSpawns;

    public float tempoAtual; // variável para sabermos desde quanto tempo spawnamos o último objeto
    void Start()
    {
        
    }

    void Update()
    {
        tempoAtual -= Time.deltaTime; // Pega nosso tempo atual de jogo e diminui pela variação do tempo do jogo, por exemplo, tempoAtual = 10s irá descontar os 10 segundos no tempo do jogo
        if(tempoAtual <= 0) // Sempre que o tempo de spawn for menor que zero, entre dois objetos , essa condicional rodará o código entre as chaves
        {
            // criando um objeto e um ponto de spawn aleatório, criando variáveis para acessar pontos aleatórios nas arrays 
            int objetoAleatorio = Random.Range(0, objetosParaSpawnar.Length); // Essa variável "objetoAleatório íra pegar os Game Objects da nossa arrray[objetosParaSpawnar] e irá gravar de maneira randômica, fazendo o cálculo autmoático pela função Lenght
            int pontoAleatorio = Random.Range(0, pontosDeSpawn.Length); // repete o mesmo  de cima, mas aqui para o lugar de spawn dos objetos do Transform da Unity, indo de 0 ao máximo de moedas que a função Lenght calcular

            //instanciando, ou spawnando, um objeto em algum ponto

            Instantiate(objetosParaSpawnar[objetoAleatorio], pontosDeSpawn[pontoAleatorio].position, pontosDeSpawn[pontoAleatorio].rotation);
            // a função Instantiate() irá criar o Game Object na posição da tela direcionada. objetosParaSpawnar[objetoAleatorio] indica para a função qual o objeto ela deverá criar na tela por vez,
            // e a pontosDeSpawn[pontoAleatorio].position irá dedeterminar o ponto na tela que esse game Object será criado, no caso, ambos serão aleatórios. para pontosDeSpawn[pontoAleatorio].rotation se relaciona a rotação de origem do ponto de spawn 
            tempoAtual = tempoEntreOsSpawns; // irá resetar a variável tempoAtual para que não fique abaixo de 0 e não gere mais objetos, essa condição será setada na Unity, por isso é passada apenas como variável em igualdade aqui pois setaremos o tempo entre os spawns na plataforma

            // Observações na plataforma:
            //                              Iremos arrastar os Prefabs que criamos para as abas Objetos Para Spawnar, no caso a Abobora e a moeda
            // Iremos clicar bo Gerador Aleatório, clicar no cadeadinho na aba inspector no canto superior direito, selecionar o Ponto (6), no caso o último,
            // e pressionado Shift, clicar no Ponto (0), no caso o primeiro. Depois arrastamos para cima do "Pontos de Spawn".
            // Delete o prefab inicial da aba Hierarchy.
            // Para aumentar a quantidade de geração de moeda ou abobora, basta arrastar mais um praf dela para a array Objetos para Sawnar, assim como feito para a moeda e abobora primeiro.
            // Podemos alterar o tempo de spawn para deixar mais frenético o game, alterar a quantidade de objetos para cair mais objetos tbm. Cabea nossa configuração.


        }





    }



}
