using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevel : UILevelAbstract
{
    private static UILevel instance;
    public static UILevel Instance => instance;

    
    [SerializeField] protected int starCount = 0;
    public int StarCount => starCount;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public virtual void OnLevelPass(int starAquired)
    {
        if (UISelectLv.CurrentLevel == UISelectLv.UnLockedLevels)
        {
            UISelectLv.UnLockedLevels++;
            PlayerPrefs.SetInt("UnLockedLevels", UISelectLv.UnLockedLevels);

        }
        if (starAquired > PlayerPrefs.GetInt("stars" + UISelectLv.CurrentLevel.ToString(), 0))
        {
            PlayerPrefs.SetInt("stars" + UISelectLv.CurrentLevel.ToString(), starAquired);
        }
           
    }
    public virtual void GameOver()
    {
        this.UILevelCtrl.UILose.gameObject.SetActive(true);
        this.UILevelCtrl.Timer.enabled = false;
        foreach(ObjectMovement item in this.UILevelCtrl.MoveObjs)
        {
            item.enabled = false;  
        }
    }
    public virtual void Defeat() {
        this.UILevelCtrl.UIWin.gameObject.SetActive(true);
        this.UILevelCtrl.Timer.enabled = false;
        foreach (ObjectMovement item in this.UILevelCtrl.MoveObjs)
        {
            item.enabled = false;
        }
        for (int i = 0;i < this.starCount; i++)
        {
            this.UILevelCtrl.Stars[i].sprite = this.UILevelCtrl.StarYellow;
        }
        this.OnLevelPass(starCount);
    }
    
    public virtual void ReLoad()
    {
        SceneManager.LoadScene("Level" + (UISelectLv.CurrentLevel + 1));
    }
    public virtual void SetStarCount(int count)
    {
        this.starCount = count;
    }
}
