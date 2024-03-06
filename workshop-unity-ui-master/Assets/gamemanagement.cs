using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanagement : MonoBehaviour
{
    public TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        score.SetText(PlayerPrefs.GetInt("scorecoin").ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pass(){
        SceneManager.LoadScene(1);
    }
}
