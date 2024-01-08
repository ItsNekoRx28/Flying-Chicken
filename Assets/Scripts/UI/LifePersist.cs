using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifePersist : MonoBehaviour
{

    void Start(){

        PlayerPrefs.SetInt("levelLife", PlayerPrefs.GetInt("life"));
        
    }

}