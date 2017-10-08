using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorDeCruzamento : MonoBehaviour
{
	[SerializeField] private Jogador jogador;
	private void OnTriggerEnter(Collider collider)
	{
		if (collider.CompareTag("Inimigo"))
		{
			Debug.Log("Chegou no fim do caminho");
			Destroy(collider.gameObject);
			jogador.PerdeVida();
		}
	}
}
