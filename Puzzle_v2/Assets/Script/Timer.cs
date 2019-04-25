using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Transform timer_bar_;
    public Transform text_indicator_;
    public Transform text_left_;
    public Transform text_time_over_;
    public Transform button_retry_;
    [SerializeField] private float current_amount_;
    [SerializeField] private float speed_;

    public GameObject plustime_pf_;

    public int bonus_time_ ;

    private void Start()
    {
        
        GameManager.is_game_over_ = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.plus_time_flag_)
        {
            if(GameManager.is_game_over_ == false)
            {
                setTimerplus(bonus_time_);
                plustime_pf_.GetComponent<CreateOBJ>().CreatePlusTimeOBJ(bonus_time_);
            }
        }

        if(current_amount_ > 1)
        {
            current_amount_ -= speed_ * Time.deltaTime;
            text_indicator_.GetComponent<Text>().text = ((int)current_amount_).ToString() + "Sec";
            text_left_.gameObject.SetActive(true);
            text_time_over_.gameObject.SetActive(false);
        }
        else
        {
            text_left_.gameObject.SetActive(false);
            text_time_over_.gameObject.SetActive(true);
            button_retry_.gameObject.SetActive(true);
            text_indicator_.GetComponent<Text>().text = "OVER!";

            GameManager.is_game_over_ = true;
            
        }
        if(current_amount_ < 40)
        {
            //timerbar.color orange?
        }
        else if(current_amount_ < 10)
        {
            //timerbar.color red?
        }

        timer_bar_.GetComponent<Image>().fillAmount = current_amount_ / 60;
    }

    public void setTimerplus(int amount)
    {
        this.current_amount_ += amount;

        

        if (this.current_amount_ > 60)
        {
            this.current_amount_ = 60;
        }
        GameManager.plus_time_flag_ = false;
    }
}
