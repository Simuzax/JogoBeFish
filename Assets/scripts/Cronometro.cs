using System;
using System.Collections;
using UnityEngine;

/*
	Cronômetro utilizando coroutines:
	Para testar, coloque esse script em algum Game Object na cena
	O campo "tempo" no inspector determina por quanto tempo o cronômetro irá funcionar
	Para iniciar o cronômetro, aperte a tecla "Espaço"
	Uma vez que o cronômetro inicia, só é possível reiniciá-lo depois que finalizar a contagem
*/

public class Cronometro : MonoBehaviour
{
    private bool contandoTempo = false;

    public event Action OnTimerEnded;

    public float tempo;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && contandoTempo == false)
        {
            StartCoroutine(IniciarContagem(tempo));
        }
    }

    IEnumerator IniciarContagem(float tempoLimite)
    {
        float tempo = 0;

        contandoTempo = true;

        Debug.Log("Início do cronômetro");

        while (tempo < tempoLimite)
        {
            tempo += Time.deltaTime;

            //Fazer alguma coisa enquanto o tempo não atinge o limite

            yield return null;
        }

        //Executar alguma função depois que o cronômetro terminou

        //Executando um evento, por exemplo
        if (OnTimerEnded != null)
            OnTimerEnded();

        Debug.Log("Fim do cronômetro");

        contandoTempo = false;
    }

    //Outra versão do cronômetro, essa só espera o tempo passar e não pode fazer nada enquanto ele não termina
    IEnumerator CronometroAlternativo(float tempoLimite)
    {
        Debug.Log("Início do cronômetro");

        yield return new WaitForSeconds(tempoLimite);

        Debug.Log("Fim do cronômetro");
    }
}
