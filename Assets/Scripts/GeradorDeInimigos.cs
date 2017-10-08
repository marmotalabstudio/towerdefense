using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeInimigos : MonoBehaviour
{

	[SerializeField] private GameObject inimigo;
	private float tempoDeCriacao = 2f;
	private float momentoDaUltimaGeracao;
	
	// Update is called once per frame
	void Update ()
	{
		GeraInimigo();
	}

	private void GeraInimigo()
	{
		float tempoAtual = Time.time;
		if (tempoAtual > momentoDaUltimaGeracao + tempoDeCriacao)
		{
			momentoDaUltimaGeracao = tempoAtual;
			Vector3 posicaoDoGerador = this.transform.position;
			Instantiate(inimigo, posicaoDoGerador, Quaternion.identity);
		}
	}
}
