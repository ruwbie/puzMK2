using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOBJ : MonoBehaviour
{
    public GameObject plus_time_;


    public void CreatePlusTimeOBJ(int amount)
    {
        Instantiate(plus_time_, this.transform);

        plus_time_.GetComponent<TimePopup>().SetText(amount) ;
    }
}
