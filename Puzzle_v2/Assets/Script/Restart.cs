using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private float save_MAX_;

    private void Start()
    {
        save_MAX_ = GameManager.MAX_alive_points_;
    }

    public void RestartGame() 
    {
        GameManager.remained_counts_ = 0.0f;
        GameManager.MAX_alive_points_ = save_MAX_; //???
        Score.score_int_ = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
