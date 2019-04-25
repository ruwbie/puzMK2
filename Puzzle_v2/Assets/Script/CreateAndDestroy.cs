using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAndDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject smaller_clone_ = null;
    private Vector3 smaller_one_spawn_position_;

    private float offset_ = 0.1f;

    public Transform score_popup_transform_;
    //public Transform plus_time_transform_;


    private float this_mass_;

    public float remained_count_;
    private float disappear_count_;
    

    private void Start()
    {
        this_mass_ = this.gameObject.GetComponent<Rigidbody2D>().mass;
        GameManager.remained_counts_ += remained_count_;
        disappear_count_ = 5;

        //this.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 200);    //生成時のはじける動きを再現してみよう。
    }

    private void Update()
    {
        if (this.gameObject != GameManager.targeted_object_ && this.gameObject.GetComponent<Status>().homing_ == false)
        {
            if (remained_count_ < 0.4)  //magicNum
            {

                disappear_count_ -= 1 * Time.deltaTime;
                if (disappear_count_ < 0)
                {
                    this.GetComponent<SpriteRenderer>().color -= new Color(0,0,0,1f) * Time.deltaTime;

                    if(this.GetComponent<SpriteRenderer>().color.a < 0)
                    {
                        GameManager.remained_counts_ -= remained_count_;
                        Destroy(this.gameObject);
                    }
                }
            }
        }


        if (Input.GetMouseButtonUp(0))
        {

            if (this.gameObject.GetComponent<Status>().homing_ || this.gameObject == GameManager.targeted_object_)
            {
                if (smaller_clone_ != null)
                {
                    for (int i = 0; i < 3; ++i)
                    {

                        SetPosition(i);

                        GameObject smallerclone =  Instantiate(smaller_clone_, smaller_one_spawn_position_, Quaternion.identity);
                        smallerclone.GetComponent<Rigidbody2D>().AddForce(SetVector() * 250);


                    }
                }
                else
                {

                    ScorePopup.Create(score_popup_transform_, this.transform.position, 100);
                    int tempRand = Random.Range(0, 200);

                    if (tempRand < 2)
                    {
                        //time+
                        if (GameManager.is_game_over_ == false)
                        {
                            GameManager.plus_time_flag_ = true;
                        }
                    }
                    if (tempRand < 4)
                    {
                        GameManager.SetMaxAlivePointPlus();
                    }

                    if (Score.score_int_ >= 9999900)
                    {
                        return;
                    }
                    Score.score_int_ += 100;


                }
                GameManager.remained_counts_ -= remained_count_;
                Destroy(this.gameObject);

            }
        }
    }



    private void SetPosition(int i)
    {
        int tempint = 1;
        if (i % 2 != 0)
        {
            tempint *= -1;
        }
        smaller_one_spawn_position_ = new Vector3(this.transform.position.x - offset_ + (offset_ * i),
            this.transform.position.y - (offset_ * tempint),
            0);
    }

    private Vector2 SetVector()
    {
        Vector2 direction = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
        return direction;
    }
}
