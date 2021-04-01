using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecSpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    private float spawnRange = 9;
    
    public int enemycount;
    public int enemyWave;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(powerUpPrefab, GenerateSpawnPos(), powerUpPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemycount = FindObjectsOfType<Enemy>().Length;

        if (enemycount == 0){
            enemyWave++;
            SpawnEnemys(enemyWave);
            Instantiate(powerUpPrefab, GenerateSpawnPos(), powerUpPrefab.transform.rotation);
        }
        if (enemyWave == 5){
            SceneManager.LoadScene("EndWin");
        }
    }
    private Vector3 GenerateSpawnPos(){
         float SpawnPosX = (Random.Range(-spawnRange, spawnRange));
        float SpawnPosZ = (Random.Range(-spawnRange, spawnRange));
        Vector3 RandomSpawn = new Vector3(SpawnPosX, 0, SpawnPosZ);
        return RandomSpawn;
    }
    void SpawnEnemys(int enemiesToSpawn){
        for (int i = 0; i < enemiesToSpawn; i++){
        Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }
}

