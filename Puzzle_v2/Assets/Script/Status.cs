using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Status : MonoBehaviour
{
    
    public bool homing_ = false;

    private Rigidbody2D rigidbody_;

    private float gravity_scale_;

    BeansAnimationController animation_controller_;



    // Start is called before the first frame update
    void Start()
    {
        
        rigidbody_ = GetComponent<Rigidbody2D>();
        gravity_scale_ = this.gameObject.GetComponent<Rigidbody2D>().gravityScale;

        animation_controller_ = this.gameObject.GetComponent<BeansAnimationController>();
    }


    private void FixedUpdate()
    {
        if (homing_)
        {
            this.gameObject.GetComponent<BeansAnimationController>().SetTappedOn();
        }
        if(this.gameObject == GameManager.targeted_object_ || this.homing_)
        {
            this.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 255);
        }
    }


    public void SetTargetT()
    {
        animation_controller_.SetTappedOn();
        GameManager.targeted_object_ = this.gameObject;
        GravityZero();
    }

    public void SetHomingT()
    {
        animation_controller_.SetTappedOn();
        this.homing_ = true;
        GravityZero();
    }

    public void SetHomingF()
    {
        this.homing_ = false;
    }

    public void GravityZero()
    {
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    public void GravityOn()
    {
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = gravity_scale_;
    }
}
