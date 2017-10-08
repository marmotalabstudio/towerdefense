using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{

	[SerializeField] private int vida;


	public int GetVida()
	{
		return vida;
	}

	public void PerdeVida()
	{
		if (EstaVivo())
		{
			vida--;
		}
	}

	public bool EstaVivo()
	{
		return vida > 0;
	}
}
