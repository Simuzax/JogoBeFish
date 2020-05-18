using System.Collections;
using UnityEngine;

public class SpawnInimigo : MonoBehaviour
{
    public Transform LinhaDeSpawn;

    public bool contarTempo = false;

    public GameObject tubaraoPrefab;
    public GameObject iscaPrefab;
    public GameObject redeDePescaPrefab; 

    [SerializeField]
    private Transform objectPoolTransform = null;

    public const int tamanhoPool = 3;

    public GameObject[] objetosObstaculosIsca;
    public GameObject[] objetosObstaculosRede;
    public GameObject[] objetoObstaculoTubarao;

    public GameObject[] arrayObstaculo;

    public void Start()
    {
        objetosObstaculosIsca = new GameObject[tamanhoPool];
        objetosObstaculosRede = new GameObject[tamanhoPool];
        objetoObstaculoTubarao = new GameObject[tamanhoPool];

        for (int i = 0; i < tamanhoPool; i++)
        {
            //Criando uma referência para o objeto instanciado
            var isca = Instantiate(iscaPrefab);
            //Resetar a posição do game object
            isca.transform.position = Vector3.zero;
            //Desativar o game object instanciado
            isca.SetActive(false);
            //Definir a referência de transform "objectPoolTransform" como o pai deste objeto
            isca.transform.SetParent(objectPoolTransform);
			//Atribuir o game object em uma posição do vetor
            objetosObstaculosIsca[i] = isca;            

            var redeDePesca = Instantiate(redeDePescaPrefab);
            redeDePesca.transform.position = Vector3.zero;
            redeDePesca.SetActive(false);
            redeDePesca.transform.SetParent(objectPoolTransform);
            objetosObstaculosRede[i] = redeDePesca;            

            var tubarao = Instantiate(tubaraoPrefab);
            tubarao.transform.position = Vector3.zero;
            tubarao.SetActive(false);
            tubarao.transform.SetParent(objectPoolTransform);
            objetoObstaculoTubarao[i] = tubarao;            
        }

		StartCoroutine("TubaraoObstaculo");
        StartCoroutine("RedeObstaculo");
        StartCoroutine("IscaObstaculo");
    }

    public void SpawnObstaculo(GameObject obstaculo, float valorMinimo, float valorMaximo)
    {
        //Posiciona o game object na linha de spawn
        obstaculo.transform.position = NovaPosicao(valorMinimo, valorMaximo);
        //Ativa o game object na hierarquia
        obstaculo.SetActive(true);
    }

    public Vector2 NovaPosicao(float valorMinimo, float valorMaximo)
    {
        Vector2 posicaoAleatoria;

        float EixoX = LinhaDeSpawn.position.x;
        float EixoY = Random.Range(valorMinimo, valorMaximo);

        posicaoAleatoria = new Vector2(EixoX, EixoY);

        return posicaoAleatoria;
    }

    public GameObject GetFromIsca()// o objetivo desta função é achar objetos desativados? //por que?
    {
        //Variável indexadora (conta as repetições)
        int i = 0;
        //Sinalizador para indicar caso uma condição tenha sido atingida
        bool flag = false;
        //Referência para um game object do array inicializada como nula
        GameObject obstaculo = null;
		//Enquanto o contador não tiver o mesmo valor do tamanho do vetor
        //E, o sinalizador for falso...
        while (i < objetosObstaculosIsca.Length && flag == false) // por que usar while em vez de for aqui?
        {
            //Se o objeto correspondente ao indexador estiver (des)//??ativo na hierarquia...
            if (!objetosObstaculosIsca[i].activeInHierarchy)
            {
                //Alterar o valor do sinalizador
                flag = true;
                //Atribuir este objeto na referência
                obstaculo = objetosObstaculosIsca[i];
            }
            //Adicionar um(1) ao valor do indexador
            i++;
        }
		//Retornar a referência do game object
		return obstaculo;
	}

    public GameObject GetFromRede()
    {
        int i = 0;
        GameObject obstaculo2 = null;

        while (i < objetosObstaculosRede.Length)
        {
            if (!objetosObstaculosRede[i].activeInHierarchy)
            {
                obstaculo2 = objetosObstaculosRede[i];
            }
            i++;
        }
        return obstaculo2;
    }

    public GameObject GetFromTubarao()
    {
        int i = 0;
        GameObject obstaculo3 = null;

        while(i < objetoObstaculoTubarao.Length)
        {
            if (!objetoObstaculoTubarao[i].activeInHierarchy)
            {
                obstaculo3 = objetoObstaculoTubarao[i];
            }
            i++;
        }
        return obstaculo3;
    }
    
    IEnumerator IscaObstaculo()
    {
        yield return new WaitForSeconds(2);
        //Criar uma variável temporária que irá receber um Game Object da pool , aqui quando fala em pool se refere a função GetFromPool? por que chama-la de pool? 
        var inimigo = GetFromIsca();
        //Se o valor da variável não for nulo...
        if (inimigo != null)
        {
            SpawnObstaculo(inimigo, 4.0f, 14.0f);
        }
        else
		{
			//Mostrar uma mensagem de alerta no console
			//OBS.: Isso NÃO PODE acontecer, esse debug só tem o propósito de teste
			Debug.LogWarning("Não tem objetos disponíveis na pool.");
		}            
    }

    IEnumerator RedeObstaculo()
    {
        yield return new WaitForSeconds(2);

        var inimigo2 = GetFromRede();

        if (inimigo2 != null)
        {
            SpawnObstaculo(inimigo2, 4.0f, 14.0f);
        }
	}

    IEnumerator TubaraoObstaculo()
    {
        yield return new WaitForSeconds(1.5f);

        var inimigo = GetFromTubarao();

        if (inimigo != null)
        {
            SpawnObstaculo(inimigo, 4.0f, 14.0f);
        }
    }


    public void Reutilizacao(float tempoLimite, float valorMinimo, float valorMaximo)
    {
        var obstaculo = GetFromTubarao();

        if (obstaculo != null)
        {
			StartCoroutine(IniciarContagem(tempoLimite, obstaculo, valorMinimo, valorMaximo));
		}		
    }

    

    public void Reutilizacao2(float tempoLimite, float valorMinimo, float valorMaximo)
    {
        var obstaculo = GetFromIsca();

        if (obstaculo != null)
        {
            StartCoroutine(IniciarContagem(tempoLimite, obstaculo, valorMinimo, valorMaximo));
        }
    }
    public void Reutilizacao3(float tempoLimite, float valorMinimo, float valorMaximo)
    {
        var obstaculo = GetFromRede();

        if (obstaculo != null)
        {
            StartCoroutine(IniciarContagem(tempoLimite, obstaculo, valorMinimo, valorMaximo));
        }
    }




    IEnumerator IniciarContagem(float tempoLimite, GameObject inimigo, float valorMinimo, float valorMaximo)
    {
        contarTempo = true;
        float tempo = 0;

        while(tempo < tempoLimite)
        {
            tempo += Time.deltaTime;

            yield return null;
        }

        SpawnObstaculo(inimigo, valorMinimo, valorMaximo);

        contarTempo = false;
    }    
}