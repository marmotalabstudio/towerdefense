using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostradorDeVida : MonoBehaviour
{

	private Text campoTexto;
	[SerializeField] private Jogador jogador;

	// Use this for initialization
	void Start ()
	{
		campoTexto = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		campoTexto.text = "Vida: " + jogador.GetVida();
	}
}
