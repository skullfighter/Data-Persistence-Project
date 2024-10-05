using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowHighScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (MenuHandler.instance != null)
        {
            MenuHandler.instance.loadHightScore();
            bestScoreText.text = "Best Score: " + MenuHandler.instance.hightPlayerName + " : " + MenuHandler.instance.hightPlayerPoint;
        }
        else
        {
            bestScoreText.text = "Best Score: Not Available"; // Handle case where DataManager is not available
        }
    }
}