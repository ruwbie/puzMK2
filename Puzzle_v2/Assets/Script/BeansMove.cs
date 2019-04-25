using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeansMove : MonoBehaviour
{
    private Vector3 mouse_position_;

    private float delta_x_, delta_y_;

    private float offset_ = 0;

    [SerializeField]
    private Rigidbody2D rigidbody2d_;

    public string tag_;
    Status status_;

    Vector2 touchpos;

    public float stopping_distance_;


    private void Start()
    {
        status_ = this.gameObject.GetComponent<Status>();
    }

    private void FixedUpdate()
    {
        float gx = Input.acceleration.x * 9.81f;
        float gy = Input.acceleration.y * 9.81f;
        Physics2D.gravity = new Vector2(gx, gy);
    }

    //Update is called once per frame
    void Update()//Touch の処理が入っている。
    {

        if (Input.touchCount > 0)
        {
            if(GameManager.is_game_over_)
            {
                return;
            }

            Touch touch = Input.GetTouch(0);
            touchpos = Camera.main.ScreenToWorldPoint(touch.position);

            if (status_.homing_&& Vector2.Distance(transform.position, touchpos) > stopping_distance_)
            {
                HomingtoTarget(touchpos);
            }


            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<CircleCollider2D>() == Physics2D.OverlapPoint(touchpos))
                    {
                        delta_x_ = touchpos.x - transform.position.x;
                        delta_y_ = touchpos.y - transform.position.y;
                        this.gameObject.GetComponent<Status>().SetTargetT();
                        tag_ = this.gameObject.tag;         //============================================判定の簡略化するための用意。まだ未実装
                    }
                    break;
                case TouchPhase.Moved:
                    if (this.gameObject == GameManager.targeted_object_)
                    {
                        transform.position = new Vector2(touchpos.x - delta_x_, touchpos.y - delta_y_);
                    }
                    break;
            }
        }

        pushObjectBackInFrustum(this.transform);
        
    }

    private void HomingtoTarget(Vector2 touchpos)   
    {
        transform.position = Vector2.MoveTowards(transform.position, touchpos, Time.deltaTime);
    }

    void pushObjectBackInFrustum(Transform transform)
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0.0f + offset_) { pos.x = 0.0f + offset_; }
        if (pos.x > 1.0f - offset_) { pos.x = 1.0f - offset_; }
        if (pos.y < 0.0f + offset_) { pos.y = 0.0f + offset_; }
        if (pos.y > 1.0f - offset_) { pos.y = 1.0f - offset_; }

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    

   
}
