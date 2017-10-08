using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour
{

	public GameObject projetilPrefab;
	public float tempoDeRecarga = 0.2f;
	private float momentoDoUltimoDisparo;
	private float tempoAtual;
	[SerializeField] private float raioDeAlcance;

	// Use this for initialization
	void Update ()
	{
		Inimigo alvo = EscolheAlvo();
		if (alvo != null)
		{
			Atira(alvo);
		}
	}

	private void Atira(Inimigo inimigo)
	{
		tempoAtual = Time.time;
		if (tempoAtual > momentoDoUltimoDisparo + tempoDeRecarga)
		{
			momentoDoUltimoDisparo = tempoAtual;
			GameObject pontoDeDisparo = this.transform.Find("CanhaoDaTorre/PontoDeDisparo").gameObject;
			Vector3 posicaoDoPontoDeDisparo = pontoDeDisparo.transform.position;
			GameObject projetilObject = Instantiate(projetilPrefab, posicaoDoPontoDeDisparo, Quaternion.identity);
			Missel missel = projetilObject.GetComponent<Missel>();
			missel.DefineAlvo(inimigo);
		}
	}
	
	private Inimigo EscolheAlvo()
	{
		GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");
		foreach (GameObject inimigo in inimigos)
		{
			if (EstaNoRaioDeAlcance(inimigo))
			{
				return inimigo.GetComponent<Inimigo>();
			}
		}
		return null;
	}

	private bool EstaNoRaioDeAlcance(GameObject inimigo)
	{
		Vector3 posicaoDaTorre = this.transform.position;
		Vector3 posicaoDaTorreNoPlano = Vector3.ProjectOnPlane(posicaoDaTorre, Vector3.up);
		Vector3 posicaoDoInimigo = inimigo.transform.position;
		Vector3 posicaoDoInimigoNoPlano = Vector3.ProjectOnPlane(posicaoDoInimigo, Vector3.up);

		float distanciaParaInimigo = Vector3.Distance(posicaoDaTorreNoPlano, posicaoDoInimigoNoPlano);

		return distanciaParaInimigo <= raioDeAlcance;
	}
}
