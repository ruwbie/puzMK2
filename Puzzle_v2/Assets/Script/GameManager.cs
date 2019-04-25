using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager 
{
    public static bool is_game_over_;

    //test
    public static float remained_counts_ = 0.0f;
    public static float MAX_alive_points_ = 8.1f;

    public static bool plus_time_flag_ = false;

    public static GameObject targeted_object_;

    public static void SetMaxAlivePointPlus()
    {
        MAX_alive_points_+= 0.2f;
    }

    
}
