using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour {

    public GameObject wordPrefab;
    public Transform wordCanvas;

public WordDisplay SpawnWord()
    {
        Vector3 randomPositon = new Vector3(Random.Range(-2.5f, 2.5f), 7f);

        GameObject wordObj =  Instantiate(wordPrefab, randomPositon, Quaternion.identity, wordCanvas);
        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();

        return wordDisplay;
    }
}
