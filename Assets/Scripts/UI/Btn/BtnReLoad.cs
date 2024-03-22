using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnReLoad : BaseBtn
{
    protected override void OnClick()
    {
        UILevel.Instance.ReLoad();
        

    }
}
