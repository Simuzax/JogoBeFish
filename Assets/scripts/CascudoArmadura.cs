using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CascudoArmadura : MonoBehaviour
{

   
    public bool armadura = true;

    
    [SerializeField]
    private float reativarArmaduraInicial;

    [SerializeField]
    private float reativarArmaduraMax;

    
    public bool intervaloDeColisao=false;

    [SerializeField]
    private float reativarArmaduraInicialsegunda;

    [SerializeField]
    private float reativarArmaduraMaxsegunda;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        reativarArmaduraInicial += Time.deltaTime;
        if (reativarArmaduraInicial >= reativarArmaduraMax && armadura==false && intervaloDeColisao==true)
        {
            reativarArmaduraInicial = 0;
            
            armadura = false;
        }


       
        reativarArmaduraInicialsegunda += Time.deltaTime;
        if(reativarArmaduraInicialsegunda>=reativarArmaduraMaxsegunda && armadura==false && intervaloDeColisao == false)
        {
            reativarArmaduraInicialsegunda = 0;
            armadura = true;
        }

        
        
    }
   
   
}
