using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeansAnimationController : MonoBehaviour
{

    public Animator beans_animator_;


    private void Start()
    {
        InvokeRepeating("RandomTrigger", 1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {

        if(GameManager.is_game_over_)
        {
            this.enabled = false;
        }
    }

    private void RandomTrigger()    //瞬きのトリガー
    {
        float randomX = Random.Range(0, 2);
        if (randomX == 1)
        {
            beans_animator_.SetTrigger("Idle_trigger");
        }
    }

    public void SetTappedOn()
    {
        beans_animator_.SetBool("Is_tapped", true);
    }

}
