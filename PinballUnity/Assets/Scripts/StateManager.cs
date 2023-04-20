using GameManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateManagerNamespace
{
    public class StateManager : MonoBehaviour
    {
        public StateBase CurrentState;
        private Dictionary<State_Enum, StateBase> status_ = new Dictionary<State_Enum, StateBase>();
        [SerializeField] private float score_ => GameManager.Instance.ScoreManager.TotalScore;
        [SerializeField] private int lifeTimes_ => GameManager.Instance.LifeManager.Lifetimes;

        [SerializeField] private int[] ChanegeStateScore = new int[3] {1000, 15000, 30000};

        [Header("Stage Trigger")]
        [SerializeField] private bool isStage1Trigger_ = false;
        [SerializeField] private bool isStage2Trigger_ = false;
        [SerializeField] private bool isStage3Trigger_ = false;
        [SerializeField] private bool isStage4Trigger_ = false;
        [SerializeField] private bool isFinishTrigger_ = false;

        private void Start()
        {
            status_.Add(State_Enum.stage1, new Stage1(this));
            status_.Add(State_Enum.stage2, new Stage2(this));
            status_.Add(State_Enum.stage3, new Stage3(this));
            status_.Add(State_Enum.stage4, new Stage4(this));
            status_.Add(State_Enum.finish, new Finish(this));

            //start from stage1
            TransitionState(State_Enum.stage1);
        }

        void Update()
        {
            CurrentState.OnUpdate();
  
            if(score_ >= ChanegeStateScore[0] && score_ < ChanegeStateScore[1] && lifeTimes_ != 0)
            {                
                TryTransitionState(State_Enum.stage2);
            }else if(score_ >= ChanegeStateScore[1] && score_ < ChanegeStateScore[2] && lifeTimes_ != 0) {
                //Debug.Log("�����x�n��");
                TryTransitionState(State_Enum.stage3);
            }else if (score_ >= ChanegeStateScore[2] && lifeTimes_ != 0)
            {
                //Debug.Log("����Ċ����E�n��");
                TryTransitionState(State_Enum.stage4);
            }else if(lifeTimes_ == 0)
            {
                //Debug.Log("�V�E���s");
                TryTransitionState(State_Enum.finish);
            }

        }

        public void TryTransitionState(State_Enum type)
        {
            switch (type)
            {
                case State_Enum.stage1:
                    if (isStage1Trigger_)
                    {
                        break;
                    }
                    else
                    {
                        //Debug.Log("Start " + type);
                        isStage1Trigger_ = true;
                        TransitionState(type);
                    }
                    break;
                case State_Enum.stage2:
                    if (isStage2Trigger_)
                    {
                        break;
                    }
                    else
                    {
                        //Debug.Log("Start " + type);
                        isStage2Trigger_ = true;
                        TransitionState(type);
                    }
                    break;
                case State_Enum.stage3:
                    if (isStage3Trigger_)
                    {
                        break;
                    }
                    else
                    {
                        //Debug.Log("Start " + type);
                        isStage3Trigger_ = true;
                        TransitionState(type);
                    }
                    break;
                case State_Enum.stage4:
                    if (isStage4Trigger_)
                    {
                        break;
                    }
                    else
                    {
                        //Debug.Log("Start " + type);
                        isStage4Trigger_ = true;
                        TransitionState(type);
                    }
                    break;
                case State_Enum.finish:
                    if (isFinishTrigger_)
                    {
                        break;
                    }
                    else
                    {
                        //Debug.Log("Start " + type);
                        isFinishTrigger_ = true;
                        TransitionState(type);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// switch State
        /// </summary>
        public void TransitionState(State_Enum type)
        {
            if (CurrentState != null)
            {
                CurrentState.OnExit();
            }
            CurrentState = status_[type];
            CurrentState.OnEnter();
        }

        public enum State_Enum
        {
            stage1, stage2, stage3, stage4, finish
        }
    }
}

