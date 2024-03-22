using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UISelectLv : UIManager
{
 
    public static int CurrentLevel;
    public static int UnLockedLevels;
    [SerializeField] protected List<LevelObj> levelObjs;
    [SerializeField] protected UISlectLevelCtrl uISlectLevelCtrl;
   
    [SerializeField] protected SpriteRenderer spriteStarYellow;
    
    protected virtual void Start()
    {
      
        this.CheckLockAndStars();
        
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUISlectLevelCtrl();
        this.LoadLevelObjs();
        this.LoadSpriteStarYellow();
    }
    protected virtual void LoadLevelObjs()
    {
        if (this.levelObjs.Count > 0) return;
        LevelObj[] array = uISlectLevelCtrl.Content.GetComponentsInChildren<LevelObj>();
        this.levelObjs.AddRange(array);

    }
    protected virtual void LoadUISlectLevelCtrl()
    {
        if (this.uISlectLevelCtrl != null) return;
        this.uISlectLevelCtrl = transform.GetComponent<UISlectLevelCtrl>();
    }
    protected virtual void LoadSpriteStarYellow()
    {
        if (this.spriteStarYellow != null) return;
        this.spriteStarYellow = transform.Find("SpriteStarYellow").GetComponent<SpriteRenderer>();
    }


    protected virtual void CheckLockAndStars()
    {
        UnLockedLevels = PlayerPrefs.GetInt("UnLockedLevels", 0);
        for(int i = 0; i < levelObjs.Count; i++) {
            if (UnLockedLevels < i) continue;
            
                this.UnLockLv(levelObjs[i]);
            this.SetStarYellow(i);
        }

    }
    protected virtual void SetStarYellow(int i)
    {
        int stars = PlayerPrefs.GetInt("stars" + i.ToString(), 0);
        for (int j = 0; j < stars; j++)
        {
            levelObjs[i].Stars[j].sprite = spriteStarYellow.sprite;
        }

    }
    public virtual void OnClickLevel(int level)
    {
        CurrentLevel = level;
        int levelCount = CurrentLevel + 1;
        SceneManager.LoadScene("Level"+levelCount);
    }
    protected virtual void UnLockLv(LevelObj levelObj)
    {
        Transform textNum = levelObj.Button.transform.Find("TextNum");
        Transform imgLock = levelObj.Button.transform.Find("ImgNum");
        textNum.gameObject.SetActive(true);
        imgLock.gameObject.SetActive(false);
        levelObj.Button.enabled = true;
    }
   
    
  
   
}
