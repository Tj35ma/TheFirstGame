using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelAbstract : TFGMonoBehaviour
{
    
    [SerializeField] protected int currentLevel = 1;
    public int CurrentLevel => currentLevel;

    [SerializeField] protected int maxLevel = 10;
    [SerializeField] protected int nextLevelExp;

    protected abstract int GetCurrentExp();
    protected abstract bool DeductExp(int exp);

    protected virtual void FixedUpdate()
    {
        this.LevelUp();
    }

    protected virtual void LevelUp()
    {
        if (this.currentLevel >= this.maxLevel) return;
        if (this.GetCurrentExp() <= this.nextLevelExp) return;
        if (this.DeductExp(this.GetNextLevelExp())) return;
        this.currentLevel++;
    }

    protected virtual int GetNextLevelExp()
    {
        return this.nextLevelExp= this.currentLevel * 12;
    }
}
