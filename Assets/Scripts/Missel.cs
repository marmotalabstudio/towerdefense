using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missel : MonoBehaviour
{
	[Range(0,5)]
	public float velocidade;
	private Inimigo alvo;
	[SerializeField] private int pontosDeDano;

	void Start()
	{
		AutoDestroiDepoisDeSegundos(5);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Anda();
		if (alvo != null)
		{
			AlteraDirecao();
		}
	}
	
	private void AlteraDirecao()
	{
		Vector3 posicaoAtual = transform.position;
		
		Vector3 posicaoDoAlvo = alvo.transform.position;

		Vector3 direcaoDoAlvo = posicaoDoAlvo - posicaoAtual; 

		transform.rotation = Quaternion.LookRotation(direcaoDoAlvo);
	}

	private void Anda()
	{
		Vector3 posicaoAtual = transform.position;
		Vector3 deslocamento = transform.forward * Time.deltaTime * velocidade;
		transform.position = posicaoAtual + deslocamento;
	}

	private void OnTriggerEnter(Collider elementoColidido)
	{
		if (elementoColidido.CompareTag("Inimigo"))
		{
			Destroy(this.gameObject);
			Inimigo inimigo = elementoColidido.GetComponent<Inimigo>();
			inimigo.RecebeDano(pontosDeDano);
		}
	}

	private void AutoDestroiDepoisDeSegundos(float segundos)
	{
		Destroy(this.gameObject, segundos);
	}

	public void DefineAlvo(Inimigo inimigo)
	{
		alvo = inimigo;
	}
}
