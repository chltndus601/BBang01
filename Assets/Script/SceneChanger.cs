// StartScene
// by sooyeon
// Canvas > Panel2 > CloseButton

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void Change()
    {
        SceneManager.LoadScene("cottonginScene");
    }
}
