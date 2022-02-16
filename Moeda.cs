using System.Collections;
using System.Collections.Generic;
using UnityEngine;                  // c�digo comentado, se n�o quiser consultar
                                    // , apenas ignorar. Se tiver d�vidas, as anota��es podem ajudar ;D \\

public class Moeda : MonoBehaviour
{
    public AudioSource somDaMoeda; // Assim como o componentente Animator, para acessar o tipo de vari�vel, devemos cham�-la aqui, assim poderemos programar
                                   // o som de acordo com o que queremos para a scene.

    // Neste caso n�o precisaremos dos m�todos padr�es start and update, pois neste caso s� queremos identificar se o Player colidiu com a coin (Moeda)
    void OnTriggerEnter2D(Collider2D other) // neste m�todo, a vari�vel do tipo Collider2D que serve para identificar se algum Collider2D colidiu com o seu trigger.
    {         
        if(other.gameObject.CompareTag("Player")) // Verifica se o gameObeject (other) que colidiu com o jogador possui a tag "Player", se possuir, executar� o comando
        {
            GetComponent<SpriteRenderer>().enabled = false; // Acessamos o m�todo ,SpriteRenderer> da plataforma da Unity, atrav�s do GetComponent, e o desativamos, pois
                                                            // quando a moeda tocar o player, existir� um delay feito l� embaixo no c�digo Destroy, assim a moeda n�o sumiria por causa desse delay.
                                                            // Logo, ao tocar o player, a moeda ficar� invis�vel, dando a impress�o de ter, literalmente sumido ou destru�da, no caso.
            other.GetComponent<Jogador>().AumentarQuantidadeDeMoedas(); // Solicitamos que o objeto qcriado aqui "other" acesse (GetComponent) o nosso script, com todas as fun��es, Jogador
                                                                        // Tendo este acesso, poderemos solicitar o m�todo construtor feito, no script Jogador, "AumentarQuantidadeDeMoedas()"
            somDaMoeda.Play(); // Depois de solicitarmos o acesso do Script do jogador, pedimos aqui para ela tocar a nossa vari�vel "somDaMoeda".
            Debug.Log("Moeda colidiu com o Player");
            Destroy(this.gameObject, 0.6f); // este m�todo destr�i a nossa moeda, no caso ser� o gameObject indicado pelo "this", que seria a
                                      // a vari�vel other que podemos chamar da nossa moeda. Este m�todo deve ser usado sempre no final do c�digo do m�todo
                                      // sen�o apagar� o gameObject antes dele aparecer. O 0.6f significa o delay para que o som da moeda possa tocar
                                      // antes dela ser destru�da. Este valor pode ser regulado de acordo com o som.

        }
        
    }

}
