using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    public bool playerActive = true;

    public int quests = 0;
    public int cog = 0;


    public void CheckForWin() {

        if (quests == 3 && cog == 2) {
            SceneManager.LoadScene("MainScene");
        }
    
    }

    private void Update() {
        CheckForWin();
    }

}
