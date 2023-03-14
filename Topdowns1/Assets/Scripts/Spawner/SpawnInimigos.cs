using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInimigos : MonoBehaviour
{
    public GameObject inimigoPrefab;
    public float spawnInterval = 7f; // Tempo para cada spawn
    public int enemiesPerSpawn = 10; // Quantidade de inimigos spawnados 
    public float spawnAreaWidth = 10f; // Largura (em unidades de espa�o) da �rea retangular em que os inimigos ser�o gerados aleatoriamente.
    public float spawnAreaLength = 10f; // Comprimento (em unidades de espa�o) da �rea retangular em que os inimigos ser�o gerados aleatoriamente. 
    public float spawnHeight = 1f; // Altura (em unidades de espa�o) em que os inimigos ser�o gerados aleatoriamente em rela��o ao plano da cena.

    void Start()
    {
        InvokeRepeating("SpawnEnemies", 0f, spawnInterval);
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemiesPerSpawn; i++)
        {
            Vector3 spawnPosition = new Vector3(
                transform.position.x + Random.Range(-spawnAreaWidth / 2f, spawnAreaWidth / 2f),
                spawnHeight,
                transform.position.z + Random.Range(-spawnAreaLength / 2f, spawnAreaLength / 2f)
            );
            Instantiate(inimigoPrefab, spawnPosition, Quaternion.identity);
        }
    }
}