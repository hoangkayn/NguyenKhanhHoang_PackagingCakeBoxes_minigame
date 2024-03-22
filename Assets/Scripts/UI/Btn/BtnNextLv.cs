using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class BtnNextLv : BaseBtn
{
    protected override void OnClick()
    {
        if (UISelectLv.CurrentLevel >= 2) return;
        UISelectLv.CurrentLevel++;
        SceneManager.LoadScene("Level" + (UISelectLv.CurrentLevel+1));
    } 
}
