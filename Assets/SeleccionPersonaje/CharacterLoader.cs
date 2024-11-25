using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    public GameObject[] characterPrefabs; // Prefabs de los personajes.
    public Transform spawnPoint; // Punto de aparición.

    void Start()
    {
        int selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        Instantiate(characterPrefabs[selectedCharacterIndex], spawnPoint.position, Quaternion.identity);
    }
}

