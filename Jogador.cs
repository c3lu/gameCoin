using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Jogador : MonoBehaviour
{
    public float velocidadeDoJogador; // Ir� gerar a op��o para setar a velocidade do player
    public Animator oAnimador; // vari�vel do tipo Animator, tipo esse herdado da biblioteca Unity. Esta vari�vel ir� ativar a anima��o do player
    public int quantidadeDeMoedas;
    public Text textoDasMoedasAtuais; // para fazer essa vari�vel para a interface de usu�rio, � necess�rio importar a biblioteca UnityEngine.UI
    public GameObject painelDeGameOver; // Vari�vel para ativar a UI para a Unity poder acessar na fun��o Game Over l� embaixo
    public Text textoDePontuacao;
    public Text textoDeHighScore;

    void Start()
    {
        quantidadeDeMoedas = 0; // para iniciar a Interface do Usu�rio UI a partir de 0
        textoDasMoedasAtuais.text = "X" + quantidadeDeMoedas; // Manda ela iniciar com os valores iniciais na UI de 0
        oAnimador = GetComponent<Animator>();
    }

    
    void Update()
    {
        MovimentarJogador(); // Ir� alterar as dire��es do player, conforme as intru��es abaixo
    }

    public void MovimentarJogador()
    {
        float comandosDoTeclado = Input.GetAxisRaw("Horizontal") * velocidadeDoJogador * Time.deltaTime; 
        // Este comando " GetAxisRaw() " identifica se o pc recebeu algum comando do teclado ou controle para algum eixo, nete caso, ser� para o eixo Horizontal
        //Time.captureDeltaTime faz com que a movimenta��o do jogador seja a mesma para todos os pcs, independente do FPS.
        //A velocidade ser� setada na pr�pria Unity, na op��o dispon�vel criada atrav�s da vari�vel velocidadeDoJogador

        transform.position = new Vector3((transform.position.x + comandosDoTeclado), transform.position.y, transform.position.z); 
        // transform.position � o mesmo item da interface da Unity, mas aqui pedimos para ele mudar o eixo x conforme progamamos, depois apenas mantemos os outros eixo que devem continuar no c�digo.

        if(comandosDoTeclado > 0.01f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            // GetComponent pega qualquer m�todo da plataforma da Unity. Dessa maneira que usamos, o SpriteRenderer > flipx = false ir�o
            // desativar o flip no eixo x, evitando com que ele vire quando a vari�vel comandosDoTeclado for maior que o n�mero positivo 0.01

        }

        if(comandosDoTeclado < - 0.01f)
        {
            GetComponent <SpriteRenderer>().flipX = true;
            // neste caso se o valor da vari�vel comandosDoTeclado for menor do que o n�mero negativo - 0.01, ele ir� girar para esquerda

        }

        if(comandosDoTeclado == 0) // s� mudar o nome das anima��es parado e andando para mudar a anima��o do personagem
        {
            oAnimador.Play("PlayerParado"); // ativando a minha anima��o "PlayerParado" para que ela possa ser animada

        }
        else
        {
            oAnimador.Play("PlayerAndando"); // ativando a minha anima��o "PlayerAndando" para que ela possa ser animada e andar

        }
    }
    // Fazer m�todo da moeda agora, fora do m�todo de MovimentarJogar(), que se encerra aqui \\

    public void AumentarQuantidadeDeMoedas()
    {
        quantidadeDeMoedas += 1; // Quando a moedinha encostar no Player, ela sempre ir� registrar a soma de mais um no score
        textoDasMoedasAtuais.text = "X" + quantidadeDeMoedas; // � necess�rio usar .text pois o componenete Text possui outros v�rios componentes, como a sombra, outlline etc.
        // usamos "X" para iniciar a contagem com a letra x e, depoi, a soma da vari�vel quantidadeDeMoedas. Poderia usar o m�todo .ToString(), mas s� mostraria os n�meros, sem o "X"
        // por estarmos passando uma string, o "X" no caso,junto com um n�mero (quantidadeDeMoedas), a Unity entende que dever� converter tudo para String, j� que a linha exige que seja convertido para um texto e n�o um n�mero.
    }

    public void GameOver()
    {
        Time.timeScale = 0f; // Este comando diz para a Unity a que velocidade nosso game tem que rodar, no caso, ser� a 0f (f identificando que � um float) porcentagem do frame, ou seja, ir� parar o game quando a ab�bora acert�-lo
        painelDeGameOver.SetActive(true); // essa fun��o tem a incub�ncia de ativar (true) ou destativar (false) o Game Object na tela do usu�rio, no caso a tela de Game Over ser� desmarcada e, toda vez que a abobora acertar o boneco, ela ligar� e aparecer� a tela.
        textoDePontuacao.text = "PONTUA��O: " + quantidadeDeMoedas; // nesse comando, ao ser acertado pela ab�bora, a pontua��o ser� mostrada na tela. Mas teremos que arrastar o Game Object UI "Pontua��o Texto" para a vari�vel Texto de Pontua��o na aba inspector, apara relacionarmos os comandos

        if(quantidadeDeMoedas > PlayerPrefs.GetInt("HighScore")) // A fun��o PlayerPrefs.GetInt serve para salvar e carregar, como no caso, informa��es na Unity. O Get Serve par a Unity acerssar o PlayerPrefs e verificar o valor definido no set abaixo
        {
            PlayerPrefs.SetInt("HighScore", quantidadeDeMoedas); // Iremos referenciar qual foi a "quantidadeDeMoedas" e salvariamos no Highscore, caso fosse maior do que o HIGHSCORE anteriormente salvo.
        }
        textoDeHighScore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore"); // Aqui iremos, apenas, printar o HIGHSCORE atual na tela, que seria a string "HIGHSCORE: " + a fun��o que buscar� o �ltimo HIGHSCORE salvo PlayerPrefs.GetInt("HighScore")


        Debug.Log("Aboborou!");


    }


}
