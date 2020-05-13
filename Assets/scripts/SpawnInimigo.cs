using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnInimigo : MonoBehaviour
{
    public Transform LinhaDeSpawn;

    public int valorObjeto = 0;
    

    public GameObject tubaraoPrefab;
    public GameObject iscaPrefab;
    public GameObject redeDePescaPrefab;

  

    [SerializeField]
    private Transform objectPoolTransform = null;       //Transform que possui relação de parentesco com os objetos intanciados
                                                        //para que serve o null nesta parte?                                              
                                                        /*              
                                                        Organizar melhor essas variáveis, documentar, e avaliar a necessidade
                                                        */

    [SerializeField]
    private float spawnarTubaraoInicial;
    [SerializeField]
    private float spawnarTubaraoMax;

    [SerializeField]
    private float spawnarIscaInicial;
    [SerializeField]
    private float spawnarIscaMax;

    [SerializeField]
    private float spawnarRedeInicial;
    
    [SerializeField]
    private float spawnarRedeMax;




    public const int tamanhoPool = 1;  //Inteiro constante que diz o tamanho do array da object pool    //por que constante?


    public GameObject[] objetosObstaculosIsca;                 //Vetor que armazena os obstaculos instanciados
    public GameObject[] objetosObstaculosRede;                                                       //aqui quando se diz pool se refere ao array e object se refere ao tipo do array que é de GameObject?
    public GameObject[] objetoObstaculoTubarao;



    public void Start() //posso colocar o que esta abaixo num update? 
    {
        objetosObstaculosIsca = new GameObject[tamanhoPool]; //pq definir o valor do vetor como 6? 
        objetosObstaculosRede = new GameObject[tamanhoPool];
        objetoObstaculoTubarao = new GameObject[tamanhoPool]; 
        for (int i = 0; i < tamanhoPool; i++)
        {
            //Criando uma referência para o objeto instanciado
            var obstaculo = Instantiate(iscaPrefab);
            //Resetar a posição do game object
            obstaculo.transform.position = Vector3.zero;
            //Desativar o game object instanciado
            obstaculo.SetActive(false);
            //Definir a referência de transform "objectPoolTransform" como o pai deste objeto
            obstaculo.transform.SetParent(objectPoolTransform); //por que transformar o objeto obstaculo em filho do objectPoolTransform? para a hierarchy ficar mais organizada
                                                                //Atribuir o game object em uma posição do vetor
            objetosObstaculosIsca[i] = obstaculo;
            StartCoroutine("IscaObstaculo");
            
            

            var obstaculo2 = Instantiate(redeDePescaPrefab);
            obstaculo2.transform.position = Vector3.zero;
            obstaculo2.SetActive(false);
            obstaculo2.transform.SetParent(objectPoolTransform);

            objetosObstaculosRede[i] = obstaculo2;
            StartCoroutine("RedeObstaculo");
            
            

            var obstaculo3 = Instantiate(tubaraoPrefab);
            obstaculo3.transform.position = Vector3.zero;
            obstaculo3.SetActive(false);
            obstaculo3.transform.SetParent(objectPoolTransform);

            objetoObstaculoTubarao[i] = obstaculo3;
            StartCoroutine("TubaraoObstaculo");
            

        }

    }
    void Update()
    {
        if (valorObjeto == 1)
        {
           
            spawnarTubaraoInicial += Time.deltaTime;
            if(spawnarTubaraoInicial >= spawnarTubaraoMax)
            {
                
                var Inimigo1 = GetFromTubarao();

                if(Inimigo1 != null)
                {
                    SpawnObstaculo(Inimigo1, 4.0f, 14.0f);

                }
                spawnarTubaraoInicial = 0;
                valorObjeto = 0;
            }

        }
        if (valorObjeto == 2)
        {
            spawnarIscaInicial += Time.deltaTime;
            if(spawnarIscaInicial >= spawnarIscaMax)
            {
                var inimigo2 = GetFromIsca();

                if(inimigo2 != null)
                {
                    SpawnObstaculo(inimigo2, 4.0f, 14.0f);
                }
                spawnarIscaInicial = 0;
                valorObjeto = 0;
            }
        }
        if (valorObjeto == 3)
        {
            spawnarRedeInicial += Time.deltaTime;

            if (spawnarRedeInicial >= spawnarRedeMax)
            {
                var inimigo3 = GetFromRede();

                if(inimigo3 != null)
                {
                    SpawnObstaculo(inimigo3, 4.0f, 14.0f);
                }
                spawnarRedeInicial = 0;
                valorObjeto = 0;
            }
        }
            
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
        float EixoY = Random.Range(valorMinimo, valorMaximo);                       //Random.Range(4.0f, 14.0f); //na nova posição da rede no eixoY os valores do random.range poderiam ser outros

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
        GameObject obstaculo = null; // aqui se coloca o obstaculo igual a null para ele guardar objetos desativados?
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
        return obstaculo; //??	
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
        /*else
            //Mostrar uma mensagem de alerta no console
            //OBS.: Isso NÃO PODE acontecer, esse debug só tem o propósito de teste
            Debug.LogWarning("Não tem objetos disponíveis na pool.");*/
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
        yield return new WaitForSeconds(0.5f);

        var inimigo3 = GetFromTubarao();

        if (inimigo3 != null)
        {
            SpawnObstaculo(inimigo3, 4.0f, 14.0f);
        }
    }
    
}
    
	// Update is called once per frame
	/*void Update()
    {
         if(Time.time>= acelerarIscaSpawninicial + acelerarIscaSpawnMax && novoValor==true && antigoValor == false)
         {
            acelerarIscaSpawninicial = Time.time;

            spawnarIscaInicial -= maisIscas;
            spawnarIscaMax -= maisIscas;

            antigoValor = true;
         }      

        if(Time.time>=desacelerarIscaSpawnInicial+desacelerarIscaSpawnMax && novoValor==true && antigoValor == true)
        {
			desacelerarIscaSpawnInicial = Time.time;

			spawnarIscaInicial += menosIscas;
			spawnarIscaMax += menosIscas;

			novoValor = false;
			antigoValor = false;
		}      

        if(Time.time>=reacelerarIscaSpawnInicial+reacelerarIscaSpawnMax && novoValor==false && antigoValor == true)
        {
            reacelerarIscaSpawnInicial = Time.time;

            spawnarIscaInicial -= maisIscas2;
            spawnarIscaMax -= maisIscas2;

            novoValor = true;
            antigoValor = true;
        }

        spawnarIscaInicial += Time.deltaTime;
        if (spawnarIscaInicial>=spawnarIscaMax)
        {
            spawnarIscaInicial = 0;

            Vector2 position = LinhaDeSpawn.transform.position;


            SpawnarInimigos<Isca>(1, Random.Range(-1, 5), position);
        }

        spawnarTubaraoInicial += Time.deltaTime;
        if(spawnarTubaraoInicial>=spawnarTubaraoMax)
        {
            spawnarTubaraoInicial = 0;

            Vector2 position = LinhaDeSpawn.transform.position;
            
            SpawnarInimigos<Tubarao>(1, Random.Range(-1, 5), position);            
        }
        
        spawnarRedePescaInicial += Time.deltaTime;
        if(spawnarRedePescaInicial>=spawnarRedePescaMax)
        {
            spawnarRedePescaInicial = 0;

            Vector2 position = LinhaDeSpawn.transform.position;
            
          
            
            SpawnarInimigos<RedePesca>(1, Random.Range(-1, 5), position);

            
        }
    }
	*/
    /*public void SpawnarInimigos<Y>(int quantidadeIinimigos, float heightMax, Vector2 Position)
    {                                                                           
        Position.y = heightMax;

        Obstaculo[] inimigosArray = ListInimigos.ToArray();                                                

        for (int i = 0; i < inimigosArray.Length; i++)
        {
			Debug.LogWarning("SpawnInimigo");

			if (typeof(Y) == typeof(Isca))
            {
                GameObject isca = Instantiate(iscaPrefab, Position, Quaternion.identity);
                var script = isca.GetComponent<Isca>();

                ListInimigos.Add(script);
                //AdicionarOuDestruir(script);
            }
            if (typeof(Y) == typeof(Tubarao))
            {
                Tubarao tubarao = Instantiate(tubaraoPrefab, Position, Quaternion.identity).GetComponent<Tubarao>();
                var script = tubarao.GetComponent<Tubarao>();

                ListInimigos.Add(script);
                //AdicionarOuDestruir(tubarao);
            }
            if (typeof(Y) == typeof(RedePesca))
            {
                RedePesca rede = Instantiate(redeDePescaPrefab, Position, Quaternion.identity).GetComponent<RedePesca>();
                var script = rede.GetComponent<RedePesca>();

                ListInimigos.Add(script);
                //AdicionarOuDestruir(rede);
            }

            /*if (ListInimigos.Count > 0)
            {
                if (typeof(Y) == typeof(Isca))
                {
                    if (ListInimigos.OfType<Isca>().Any())
                    {
                        int posicao = ListInimigos.FindLastIndex(x => x.GetType() == typeof(Isca));

                        Obstaculo Isca = ListInimigos[posicao];

                        ListInimigos.RemoveAt(posicao);

                        Isca.transform.position = position;

						Isca.gameObject.SetActive(true);
                    }
                }
                else if (typeof(Y) == typeof(RedePesca))
                {
                    if (ListInimigos.OfType<RedePesca>().Any())
                    {
                        int possicao = ListInimigos.FindLastIndex(x => x.GetType() == typeof(RedePesca));

                        Obstaculo RedePesca = ListInimigos[possicao];

                        ListInimigos.RemoveAt(possicao);

                        RedePesca.transform.position = position;

						RedePesca.gameObject.SetActive(true);
                    }
                }
                else if (typeof(Y) == typeof(Tubarao))
                {
                    if (ListInimigos.OfType<Tubarao>().Any())
                    {
                        int possicao = ListInimigos.FindLastIndex(x => x.GetType() == typeof(Tubarao));

                        Obstaculo tubarao = ListInimigos[possicao];

                        ListInimigos.RemoveAt(possicao);

                        tubarao.transform.position = position;

						tubarao.gameObject.SetActive(true);
                    }
                }
            }*/
    //else
    //{

    //}



    /* public void AdicionarOuDestruir(Obstaculo obstaculo)                                         
    {       
        if (ListInimigos.Count > 0)
        {
            ListInimigos.Add(obstaculo);
        }
        else
        {
            Destroy(obstaculo);
        }
    }*/

