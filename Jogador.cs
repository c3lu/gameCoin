using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Jogador : MonoBehaviour
{
    public float velocidadeDoJogador; // Irá gerar a opção para setar a velocidade do player
    public Animator oAnimador; // variável do tipo Animator, tipo esse herdado da biblioteca Unity. Esta variável irá ativar a animação do player
    public int quantidadeDeMoedas;
    public Text textoDasMoedasAtuais; // para fazer essa variável para a interface de usuário, é necessário importar a biblioteca UnityEngine.UI
    public GameObject painelDeGameOver; // Variável para ativar a UI para a Unity poder acessar na função Game Over lá embaixo
    public Text textoDePontuacao;
    public Text textoDeHighScore;

    void Start()
    {
        quantidadeDeMoedas = 0; // para iniciar a Interface do Usuário UI a partir de 0
        textoDasMoedasAtuais.text = "X" + quantidadeDeMoedas; // Manda ela iniciar com os valores iniciais na UI de 0
        oAnimador = GetComponent<Animator>();
    }

    
    void Update()
    {
        MovimentarJogador(); // Irá alterar as direções do player, conforme as intruções abaixo
    }

    public void MovimentarJogador()
    {
        float comandosDoTeclado = Input.GetAxisRaw("Horizontal") * velocidadeDoJogador * Time.deltaTime; 
        // Este comando " GetAxisRaw() " identifica se o pc recebeu algum comando do teclado ou controle para algum eixo, nete caso, será para o eixo Horizontal
        //Time.captureDeltaTime faz com que a movimentação do jogador seja a mesma para todos os pcs, independente do FPS.
        //A velocidade será setada na própria Unity, na opção disponível criada através da variável velocidadeDoJogador

        transform.position = new Vector3((transform.position.x + comandosDoTeclado), transform.position.y, transform.position.z); 
        // transform.position é o mesmo item da interface da Unity, mas aqui pedimos para ele mudar o eixo x conforme progamamos, depois apenas mantemos os outros eixo que devem continuar no código.

        if(comandosDoTeclado > 0.01f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            // GetComponent pega qualquer método da plataforma da Unity. Dessa maneira que usamos, o SpriteRenderer > flipx = false irão
            // desativar o flip no eixo x, evitando com que ele vire quando a variável comandosDoTeclado for maior que o número positivo 0.01

        }

        if(comandosDoTeclado < - 0.01f)
        {
            GetComponent <SpriteRenderer>().flipX = true;
            // neste caso se o valor da variável comandosDoTeclado for menor do que o número negativo - 0.01, ele irá girar para esquerda

        }

        if(comandosDoTeclado == 0) // só mudar o nome das animações parado e andando para mudar a animação do personagem
        {
            oAnimador.Play("PlayerParado"); // ativando a minha animação "PlayerParado" para que ela possa ser animada

        }
        else
        {
            oAnimador.Play("PlayerAndando"); // ativando a minha animação "PlayerAndando" para que ela possa ser animada e andar

        }
    }
    // Fazer método da moeda agora, fora do método de MovimentarJogar(), que se encerra aqui \\

    public void AumentarQuantidadeDeMoedas()
    {
        quantidadeDeMoedas += 1; // Quando a moedinha encostar no Player, ela sempre irá registrar a soma de mais um no score
        textoDasMoedasAtuais.text = "X" + quantidadeDeMoedas; // É necessário usar .text pois o componenete Text possui outros vários componentes, como a sombra, outlline etc.
        // usamos "X" para iniciar a contagem com a letra x e, depoi, a soma da variável quantidadeDeMoedas. Poderia usar o método .ToString(), mas só mostraria os números, sem o "X"
        // por estarmos passando uma string, o "X" no caso,junto com um número (quantidadeDeMoedas), a Unity entende que deverá converter tudo para String, já que a linha exige que seja convertido para um texto e não um número.
    }

    public void GameOver()
    {
        Time.timeScale = 0f; // Este comando diz para a Unity a que velocidade nosso game tem que rodar, no caso, será a 0f (f identificando que é um float) porcentagem do frame, ou seja, irá parar o game quando a abóbora acertá-lo
        painelDeGameOver.SetActive(true); // essa função tem a incubência de ativar (true) ou destativar (false) o Game Object na tela do usuário, no caso a tela de Game Over será desmarcada e, toda vez que a abobora acertar o boneco, ela ligará e aparecerá a tela.
        textoDePontuacao.text = "PONTUAÇÃO: " + quantidadeDeMoedas; // nesse comando, ao ser acertado pela abóbora, a pontuação será mostrada na tela. Mas teremos que arrastar o Game Object UI "Pontuação Texto" para a variável Texto de Pontuação na aba inspector, apara relacionarmos os comandos

        if(quantidadeDeMoedas > PlayerPrefs.GetInt("HighScore")) // A função PlayerPrefs.GetInt serve para salvar e carregar, como no caso, informações na Unity. O Get Serve par a Unity acerssar o PlayerPrefs e verificar o valor definido no set abaixo
        {
            PlayerPrefs.SetInt("HighScore", quantidadeDeMoedas); // Iremos referenciar qual foi a "quantidadeDeMoedas" e salvariamos no Highscore, caso fosse maior do que o HIGHSCORE anteriormente salvo.
        }
        textoDeHighScore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore"); // Aqui iremos, apenas, printar o HIGHSCORE atual na tela, que seria a string "HIGHSCORE: " + a função que buscará o último HIGHSCORE salvo PlayerPrefs.GetInt("HighScore")


        Debug.Log("Aboborou!");


    }


}
