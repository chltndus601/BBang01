// cottongintScene
// by sooyeon
// grandpa letter Canvas > panel2 > CloseButton

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger2 : MonoBehaviour
{
    public void Change()
    {
        SceneManager.LoadScene("weavingScene");
    }
}
