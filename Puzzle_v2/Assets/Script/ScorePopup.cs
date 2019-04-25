using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePopup : MonoBehaviour
{
    private const float movescore_speed_ = 1f;
    private const float disappear_speed_ = 2f;
    private const float increase_scale_amount_ = 0.3f;
    private const float decrease_scale_amount_ = 0.3f;
    private float disappear_timer_MAX = 1f;
    private float disappear_timer_;
    private Vector3 move_vector_;

    private TextMeshPro textmesh_;


    private void Awake()
    {
        textmesh_ = transform.GetComponent<TextMeshPro>();
        disappear_timer_ = disappear_timer_MAX;
        move_vector_ = new Vector3(0.7f, 1) * 2f ;
    }

    public virtual void Setup(int scoreAmount)
    {
        textmesh_.SetText(scoreAmount.ToString());
        
    }

    private void Update()
    {
        transform.position += move_vector_ * Time.deltaTime;
        move_vector_ -= move_vector_ * 1.5f * Time.deltaTime;

        if(disappear_timer_ > disappear_timer_MAX * 0.5f)
        {
            transform.localScale += Vector3.one * increase_scale_amount_ * Time.deltaTime;
        }
        else
        {
            transform.localScale -= Vector3.one * decrease_scale_amount_ * Time.deltaTime;
        }

        disappear_timer_ -= Time.deltaTime;
        if(disappear_timer_ < 0)
        {
            textmesh_.color -= Time.deltaTime * new Color(0, 0, 0, disappear_speed_);
            if (textmesh_.color.a < 0)
            {
                Destroy(this.gameObject);
            }
        }
    }




    //実際に生成するクラスで呼び出せばInstantiateするメソッド
    public static ScorePopup Create(Transform transform, Vector3 position, int scoreAmount)
    {
        Transform score_popup_transform = Instantiate(transform, position, Quaternion.identity);

        ScorePopup score_popup = score_popup_transform.GetComponent<ScorePopup>();
        score_popup.Setup(scoreAmount);

        return score_popup;
    }
}
