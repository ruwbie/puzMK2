using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingHandler : MonoBehaviour
{
    public bool touched = false;

    private Status parent_object_status_;

    private void Start()
    {
        parent_object_status_ = this.gameObject.GetComponentInParent<Status>();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Status>() == null || this.enabled == false)   //エラーチェック
        {
            return;
        }

        if (collision.gameObject.CompareTag(this.gameObject.tag))   //色のタグが一致するか
        {
            if (collision.gameObject == GameManager.targeted_object_)    //ぶつかって来たGameObjectがTargetに設定されているか
            {
                if(parent_object_status_.homing_ == false)
                {
                    parent_object_status_.SetTargetT();
                    collision.gameObject.GetComponent<Status>().SetHomingT();
                }
            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        touched = false;
    }
}
