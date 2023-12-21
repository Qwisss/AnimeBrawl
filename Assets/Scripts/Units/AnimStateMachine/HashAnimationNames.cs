
using UnityEngine;

public class HashAnimationNames
{

    protected HashAnimationNames animBase;

    #region properties

    public int Idle { get => Animator.StringToHash("Idle"); }
    public int Walk { get => Animator.StringToHash("Walk"); }
    public int Run { get => Animator.StringToHash("Run"); }
    public int HightKick { get => Animator.StringToHash("HightKick"); }
    public int FightIdle { get => Animator.StringToHash("FightIdle"); }
    public int DrawArrowBow { get => Animator.StringToHash("DrawArrowBow"); }

    #endregion

}

