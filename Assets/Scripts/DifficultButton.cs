using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultButton : MonoBehaviour
{
    public int difficulty;
    private GameManager1 gameManager1;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        gameManager1 = GameObject.Find("SpawnManager").GetComponent<GameManager1>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetDifficulty()
    {
        gameManager1.StartGame(difficulty);
    }
}
