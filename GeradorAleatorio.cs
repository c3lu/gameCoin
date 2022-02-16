using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorAleatorio : MonoBehaviour
{
    public GameObject[] objetosParaSpawnar;
    public Transform[] pontosDeSpawn;

    public float tempoEntreOsSpawns;

    public float tempoAtual; // vari�vel para sabermos desde quanto tempo spawnamos o �ltimo objeto
    void Start()
    {
        
    }

    void Update()
    {
        tempoAtual -= Time.deltaTime; // Pega nosso tempo atual de jogo e diminui pela varia��o do tempo do jogo, por exemplo, tempoAtual = 10s ir� descontar os 10 segundos no tempo do jogo
        if(tempoAtual <= 0) // Sempre que o tempo de spawn for menor que zero, entre dois objetos , essa condicional rodar� o c�digo entre as chaves
        {
            // criando um objeto e um ponto de spawn aleat�rio, criando vari�veis para acessar pontos aleat�rios nas arrays 
            int objetoAleatorio = Random.Range(0, objetosParaSpawnar.Length); // Essa vari�vel "objetoAleat�rio �ra pegar os Game Objects da nossa arrray[objetosParaSpawnar] e ir� gravar de maneira rand�mica, fazendo o c�lculo autmo�tico pela fun��o Lenght
            int pontoAleatorio = Random.Range(0, pontosDeSpawn.Length); // repete o mesmo  de cima, mas aqui para o lugar de spawn dos objetos do Transform da Unity, indo de 0 ao m�ximo de moedas que a fun��o Lenght calcular

            //instanciando, ou spawnando, um objeto em algum ponto

            Instantiate(objetosParaSpawnar[objetoAleatorio], pontosDeSpawn[pontoAleatorio].position, pontosDeSpawn[pontoAleatorio].rotation);
            // a fun��o Instantiate() ir� criar o Game Object na posi��o da tela direcionada. objetosParaSpawnar[objetoAleatorio] indica para a fun��o qual o objeto ela dever� criar na tela por vez,
            // e a pontosDeSpawn[pontoAleatorio].position ir� dedeterminar o ponto na tela que esse game Object ser� criado, no caso, ambos ser�o aleat�rios. para pontosDeSpawn[pontoAleatorio].rotation se relaciona a rota��o de origem do ponto de spawn 
            tempoAtual = tempoEntreOsSpawns; // ir� resetar a vari�vel tempoAtual para que n�o fique abaixo de 0 e n�o gere mais objetos, essa condi��o ser� setada na Unity, por isso � passada apenas como vari�vel em igualdade aqui pois setaremos o tempo entre os spawns na plataforma

            // Observa��es na plataforma:
            //                              Iremos arrastar os Prefabs que criamos para as abas Objetos Para Spawnar, no caso a Abobora e a moeda
            // Iremos clicar bo Gerador Aleat�rio, clicar no cadeadinho na aba inspector no canto superior direito, selecionar o Ponto (6), no caso o �ltimo,
            // e pressionado Shift, clicar no Ponto (0), no caso o primeiro. Depois arrastamos para cima do "Pontos de Spawn".
            // Delete o prefab inicial da aba Hierarchy.
            // Para aumentar a quantidade de gera��o de moeda ou abobora, basta arrastar mais um praf dela para a array Objetos para Sawnar, assim como feito para a moeda e abobora primeiro.
            // Podemos alterar o tempo de spawn para deixar mais fren�tico o game, alterar a quantidade de objetos para cair mais objetos tbm. Cabea nossa configura��o.


        }





    }



}
