using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : MonoBehaviour
{
    public Transform[] mosters_;

    public Transform[] casting_pos_candidates_;

    private int rand_num_ = 0;

    private Vector3 casting_direction_;

    private Transform casting_pos_;

    private void Start()
    {
        //switch(Random.Range(0, casting_pos_candidates_.Length))
        //{
        //    case 0:
        //        casting_pos_ = casting_pos_candidates_[0];
        //        break;
        //    case 1:
        //        casting_pos_ = casting_pos_candidates_[1];
        //        break;
        //    case 2:
        //        casting_pos_ = casting_pos_candidates_[2];
        //        break;
        //    case 3:
        //        casting_pos_ = casting_pos_candidates_[3];
        //        break;

        //    default:
        //        casting_pos_ = casting_pos_candidates_[0];
        //        break;
        //}

        //if (casting_pos_.transform.position.x > 0 && casting_pos_.transform.position.y > 0)
        //{
        //    casting_direction_ = transform.up * -1;
        //}
        //else if (casting_pos_.transform.position.x < 0 && casting_pos_.transform.position.y > 0)
        //{
        //    casting_direction_ = transform.right;
        //}
        //else if (casting_pos_.transform.position.x < 0 && casting_pos_.transform.position.y < 0)
        //{
        //    casting_direction_ = transform.up;
        //}
        //else
        //{
        //    casting_direction_ = transform.right * -1;
        //}
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.remained_counts_ < GameManager.MAX_alive_points_)
        {
            RandPos();
            RandMonster();
            //Instantiate(mosters_[rand_num_],this.transform);
            Transform monster = Instantiate(mosters_[rand_num_], casting_pos_.transform);
            monster.gameObject.GetComponent<Rigidbody2D>().AddForce(casting_direction_ * 200);
        }
    }

    private void RandMonster()
    {
        rand_num_ = Random.Range(0, mosters_.Length);

        
    }
    private void RandPos()
    {
        switch (Random.Range(0, casting_pos_candidates_.Length))
        {
            case 0:
                casting_pos_ = casting_pos_candidates_[0];
                break;
            case 1:
                casting_pos_ = casting_pos_candidates_[1];
                break;
            case 2:
                casting_pos_ = casting_pos_candidates_[2];
                break;
            case 3:
                casting_pos_ = casting_pos_candidates_[3];
                break;

            default:
                casting_pos_ = casting_pos_candidates_[0];
                break;
        }
        if (casting_pos_.transform.position.x > 0 && casting_pos_.transform.position.y > 0)
        {
            casting_direction_ = transform.up * -1;
        }
        else if (casting_pos_.transform.position.x < 0 && casting_pos_.transform.position.y > 0)
        {
            casting_direction_ = transform.right;
        }
        else if (casting_pos_.transform.position.x < 0 && casting_pos_.transform.position.y < 0)
        {
            casting_direction_ = transform.up;
        }
        else
        {
            casting_direction_ = transform.right * -1;
        }
    }
}
