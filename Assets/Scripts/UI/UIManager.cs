using UnityEngine;
using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime;

public class UIManager : BaseMonoBehaviour
{
    [SerializeField] protected bool isOpen = false;
    
    public virtual void Open()
    {
        isOpen = true;
        gameObject.SetActive(true);
    }
    public virtual void Close()
    {
        isOpen = false;
        gameObject.SetActive(false);
    }


}

