using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatGui : MonoBehaviour
{
    Health _playerHealth;
    [SerializeField]
    Texture2D _gameOverImage;
    void Start()
    {
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        _playerHealth = playerGameObject.GetComponent<Health>();
    }


    void OnGUI()
 {
 if (_playerHealth.IsDead)
 {
            float x = (Screen.width - _gameOverImage.width) / 2;
            float y = (Screen.height - _gameOverImage.height) / 2;
            GUI.DrawTexture(new Rect(x, y, _gameOverImage.width, _gameOverImage.height),
            _gameOverImage);
        }
 } 
}
