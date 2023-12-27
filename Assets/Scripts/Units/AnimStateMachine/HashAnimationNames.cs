
using UnityEngine;

public class HashAnimationNames
{

    protected HashAnimationNames animBase;

    #region properties

    #region TwoHanded

    public int TwoHanded_Idle { get => Animator.StringToHash("TwoHanded_Idle"); }
    public int TwoHanded_Run { get => Animator.StringToHash("TwoHanded_Run"); }
    public int TwoHanded_Attack { get => Animator.StringToHash("TwoHanded_Attack"); }
    public int TwoHanded_Death { get => Animator.StringToHash("TwoHanded_Death"); }

    #endregion

    #endregion

}

