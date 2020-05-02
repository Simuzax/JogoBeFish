using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnInimigo : MonoBehaviour
{
    public Transform LinhaDeSpawn;
    

    public GameObject tubaraoPrefab;
    public GameObject iscaPrefab;
    public GameObject redeDePescaPrefab;

    [SerializeField]
    private float spawnarInimigoInicial;

    [SerializeField]
    private float spawnarInimigoFinal;


    [SerializeField]
    private Transform objectPoolTransform = null;       //Transform que possui relação de parentesco com os objetos intanciados
                                                        //para que serve o null nesta parte?                                              
                                                        /*              
                                                        Organizar melhor essas variáveis, documentar, e avaliar a necessidade
                                                        */

    [SerializeField]
    private float spawnarIscaInicial;
    [SerializeField]
    private float spawnarIscaMax;
    [SerializeField]
    private float spawnarTubaraoInicial;
    [SerializeField]
    private float spawnarTubaraoMax;
    [SerializeField]
    private float spawnarRedePescaInicial;
    [SerializeField]
    private float spawnarRedePescaMax;
    [SerializeField]
    float distanceEnemyFromPlayer;
    [SerializeField]
    private Transform Camera;
    [SerializeField]
    private float acelerarIscaSpawninicial;
    [SerializeField]
    private float acelerarIscaSpawnMax;
    [SerializeField]
    private float desacelerarIscaSpawnInicial;
    [SerializeField]
    private float desacelerarIscaSpawnMax;
    [SerializeField]
    private float reacelerarIscaSpawnInicial;
    [SerializeField]
    private float reacelerarIscaSpawnMax;
    [SerializeField]
    private float maisIscas;
    [SerializeField]
    private float menosIscas;
    [SerializeField]
    private float maisIscas2;

    public bool novoValor = true;
    public bool antigoValor = false;

    public List<Obstaculo> ListInimigos = new List<Obstaculo>();
    public List<GameObject> ListInimigosVivos = new List<GameObject>();

    public const int tamanhoPool = 6;  //Inteiro constante que diz o tamanho do array da object pool    //por que constante?

    
    public GameObject[] objetosObstaculos;                 //Vetor que armazena os obstaculos instanciados
                                                            //aqui quando se diz pool se refere ao array e object se refere ao tipo do array que é de GameObject?
    private void Start() //posso colocar o que esta abaixo num update? 
    {
        objetosObstaculos = new GameObject[tamanhoPool]; //pq definir o valor do vetor como 6? 

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
            objetosObstaculos[i] = obstaculo;

            //Criar uma variável temporária que irá receber um Game Object da pool , aqui quando fala em pool se refere a função GetFromPool? por que chama-la de pool? 
            var inimigo = GetFromPool();
            //Se o valor da variável não for nulo...
            if (inimigo != null)    //por que o null nessa parte?, a var inimigo não recebeu o retorno da função GetFromPool? 
            {
                //Posicionar o obstáculo na cena
                SpawnObstaculo(inimigo);
            }
            //Se for nulo...
            else
                //Mostrar uma mensagem de alerta no console
                //OBS.: Isso NÃO PODE acontecer, esse debug só tem o propósito de teste
                Debug.LogWarning("Não tem objetos disponíveis na pool.");

        }

    }
    /*private void Update()
    {
        spawnarInimigoInicial += Time.deltaTime;
        if (spawnarInimigoInicial >= spawnarInimigoFinal)
        {
            spawnarInimigoInicial = 0;

            
        }


    }*/

    private void SpawnObstaculo(GameObject obstaculo)
    {
        //Posiciona o game object na linha de spawn
        obstaculo.transform.position = LinhaDeSpawn.position;
        //Ativa o game object na hierarquia
        obstaculo.SetActive(true);
    }

    private GameObject GetFromPool()// o objetivo desta função é achar objetos desativados? //por que?
    {
        //Variável indexadora (conta as repetições)
        int i = 0;
        //Sinalizador para indicar caso uma condição tenha sido atingida
        bool flag = false;
        //Referência para um game object do array inicializada como nula
        GameObject obstaculo = null; // aqui se coloca o obstaculo igual a null para ele guardar objetos desativados?
                                     //Enquanto o contador não tiver o mesmo valor do tamanho do vetor
                                     //E, o sinalizador for falso...
        while (i < objetosObstaculos.Length && flag == false) // por que usar while em vez de for aqui?
        {
            //Se o objeto correspondente ao indexador estiver (des)//??ativo na hierarquia...
            if (!objetosObstaculos[i].activeInHierarchy)
            {
                //Alterar o valor do sinalizador
                flag = true;
                //Atribuir este objeto na referência
                obstaculo = objetosObstaculos[i];
            }
            //Adicionar um(1) ao valor do indexador
            i++;
        }
        //Retornar a referência do game object
        return obstaculo; //??		
    }
    


    /*
	// Update is called once per frame
	void Update()
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
}
