using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class ObjectMovement : BaseMonoBehaviour
{
    [SerializeField] protected ContentCtrl contentCtrl;
    [SerializeField] protected float moveSpeed = 0.1f;
    protected Transform currentSlot;
    protected int currentIndex;
    [SerializeField] protected bool isMoving = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContentCtrl();
    }

    protected virtual void LoadContentCtrl()
    {
        if (this.contentCtrl != null) return;
        this.contentCtrl = transform.parent.parent.GetComponent<ContentCtrl>();
    }

    protected virtual void Start()
    {
        this.currentSlot = transform.parent;
        this.currentIndex = contentCtrl.Slots.IndexOf(currentSlot);
    }

    protected virtual void Update()
    {
        this.CheckInput();
    }

    protected virtual void CheckInput()
    {
        if (isMoving) return;

        if (Input.GetKeyDown(KeyCode.W))
        {
            this.RequestMoveUp();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.RequestMoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            this.RequestMoveDown();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.RequestMoveRight();
        }
    }

    protected virtual void RequestMoveUp()
    {

        int newIndex = currentIndex - 3;
        while (newIndex >= 0 && newIndex % 3 == currentIndex % 3)
        {
            if (IsSlotOccupied(newIndex)) break;
            newIndex -= 3;
        }
        MoveToIndex(newIndex + 3);
    }

    protected virtual void RequestMoveDown()
    {
        int newIndex = currentIndex + 3;
        while (newIndex < contentCtrl.Slots.Count && newIndex % 3 == currentIndex % 3)
        {
            if (IsSlotOccupied(newIndex) && !contentCtrl.Slots[newIndex].GetChild(0).CompareTag("Gift")) break;
            newIndex += 3;
        }
        MoveToIndex(newIndex - 3);
    }

    protected virtual void RequestMoveLeft()
    {
        int newIndex = currentIndex - 1;
        while (newIndex >= 0 && newIndex / 3 == currentIndex / 3)
        {
            if (IsSlotOccupied(newIndex)) break;
            newIndex -= 1;
        }
        MoveToIndex(newIndex + 1);
    }

    protected virtual void RequestMoveRight()
    {
        int newIndex = currentIndex + 1;
        while (newIndex < contentCtrl.Slots.Count && newIndex / 3 == currentIndex / 3)
        {
            if (IsSlotOccupied(newIndex)) break;
            newIndex += 1;
        }
        MoveToIndex(newIndex - 1);
    }

    protected virtual void MoveToIndex(int newIndex)
    {
        isMoving = true;
        Transform target = contentCtrl.Slots[newIndex];
        transform.DOMove(target.position, moveSpeed).SetEase(Ease.Linear).OnComplete(() =>
        {
            isMoving = false;
            currentIndex = newIndex;
            currentSlot = contentCtrl.Slots[currentIndex];
            transform.SetParent(currentSlot);
            Transform child = currentSlot.GetChild(0);
            if (child != transform && child.CompareTag("Gift"))
            {
                UILevel.Instance.Defeat();
            }
        });
    }

    protected virtual bool IsSlotOccupied(int index)
    {
        return contentCtrl.Slots[index].childCount > 0;
    }
}
