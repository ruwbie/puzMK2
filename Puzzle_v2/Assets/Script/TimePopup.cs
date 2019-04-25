using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePopup :MonoBehaviour
{
    public  Text plus_text_;
    private Transform this_transform_;
    private Vector3 move_vec_;
    private float life_;

    private void Start()
    {
        this_transform_ = this.transform;
        move_vec_ = new Vector3(0, 0.5f);
        life_ = 1;
    }

    private void Update()
    {
        this.life_-= Time.deltaTime;

        if(life_ < 0)
        {
            plus_text_.color -= new Color(0, 0, 0, 0.6f) * Time.deltaTime;
            this_transform_.position += move_vec_;
        }

        if(plus_text_.color.a < 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetText(int amount)
    {
        plus_text_.text =" + " + amount.ToString() + " !! ";
    }
    
    

}
