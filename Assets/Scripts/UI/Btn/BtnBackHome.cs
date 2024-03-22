using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnBackHome : BaseBtn
{
    protected override void OnClick()
    {
        SceneManager.LoadScene("MainMenu");
        

    }
}
