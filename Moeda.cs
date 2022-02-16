using System.Collections;
using System.Collections.Generic;
using UnityEngine;                  // código comentado, se não quiser consultar
                                    // , apenas ignorar. Se tiver dúvidas, as anotações podem ajudar ;D \\

public class Moeda : MonoBehaviour
{
    public AudioSource somDaMoeda; // Assim como o componentente Animator, para acessar o tipo de variável, devemos chamá-la aqui, assim poderemos programar
                                   // o som de acordo com o que queremos para a scene.

    // Neste caso não precisaremos dos métodos padrões start and update, pois neste caso só queremos identificar se o Player colidiu com a coin (Moeda)
    void OnTriggerEnter2D(Collider2D other) // neste método, a variável do tipo Collider2D que serve para identificar se algum Collider2D colidiu com o seu trigger.
    {         
        if(other.gameObject.CompareTag("Player")) // Verifica se o gameObeject (other) que colidiu com o jogador possui a tag "Player", se possuir, executará o comando
        {
            GetComponent<SpriteRenderer>().enabled = false; // Acessamos o método ,SpriteRenderer> da plataforma da Unity, através do GetComponent, e o desativamos, pois
                                                            // quando a moeda tocar o player, existirá um delay feito lá embaixo no código Destroy, assim a moeda não sumiria por causa desse delay.
                                                            // Logo, ao tocar o player, a moeda ficará invisível, dando a impressão de ter, literalmente sumido ou destruída, no caso.
            other.GetComponent<Jogador>().AumentarQuantidadeDeMoedas(); // Solicitamos que o objeto qcriado aqui "other" acesse (GetComponent) o nosso script, com todas as funções, Jogador
                                                                        // Tendo este acesso, poderemos solicitar o método construtor feito, no script Jogador, "AumentarQuantidadeDeMoedas()"
            somDaMoeda.Play(); // Depois de solicitarmos o acesso do Script do jogador, pedimos aqui para ela tocar a nossa variável "somDaMoeda".
            Debug.Log("Moeda colidiu com o Player");
            Destroy(this.gameObject, 0.6f); // este método destrói a nossa moeda, no caso será o gameObject indicado pelo "this", que seria a
                                      // a variável other que podemos chamar da nossa moeda. Este método deve ser usado sempre no final do código do método
                                      // senão apagará o gameObject antes dele aparecer. O 0.6f significa o delay para que o som da moeda possa tocar
                                      // antes dela ser destruída. Este valor pode ser regulado de acordo com o som.

        }
        
    }

}
