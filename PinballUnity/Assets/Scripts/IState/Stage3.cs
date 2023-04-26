using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManagerNamespace;
using GameManagerNamespace;

public class Stage3 : StateBase
{
    public delegate void Stage3EventHandler(string state);
    public static Stage3EventHandler OccurStage3;

    private float recordOriginGravity_;

    private float recordOriginBounceMaxForce_;

    private float recordOriginBounceMinForce_;

    public Stage3(StateManager m) : base(m)
    {
    }

    public override void OnEnter()
    {
        GameInput.Instance.BallCanMove = false;
        OccurStage3("OnEnter");
        Debug.Log("iüstage3");
        //LIÍÌåêêy
        recordOriginGravity_ = GameInput.Instance.Gravity;
        GameInput.Instance.Gravity = recordOriginGravity_ * 2.0f;

        recordOriginBounceMaxForce_ = GameInput.Instance.BounceMaxForce;
        GameInput.Instance.BounceMaxForce = recordOriginBounceMaxForce_ * 1.3f;

        recordOriginBounceMinForce_ = GameInput.Instance.BounceMinForce;
        GameInput.Instance.BounceMinForce = recordOriginBounceMinForce_ * 1.3f;

        //VJnºJ¹CÁãºJVÁÁ

        //LóðLVã{ºÒIè¶¨½¹IâX¨(åÖ)CÁãn`n
    }

    public override void OnExit()
    {
        OccurStage3("OnExit");
        //Ò´LIÍ
        GameInput.Instance.Gravity = recordOriginGravity_;

        GameInput.Instance.BounceMaxForce = recordOriginBounceMaxForce_;

        GameInput.Instance.BounceMinForce = recordOriginBounceMinForce_;

        //èÂºJVÁÁ 

        //èÂn`n        
       
    }

    public override void OnUpdate()
    {
        
    }   
}
