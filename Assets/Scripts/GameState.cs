using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{
    public enum STATE
    {
        PLAY
    }

    public enum EVENT
    {
        EXIT, UPDATE, ENTER
    }

    public STATE name; // current state
    protected EVENT stage; // current stage
    protected GameState nextState; // next state
    protected GameManager gameManager;

    public GameState()
    {
        gameManager = gameManager.instance();
    }

    public virtual void Enter()
    {
        stage = EVENT.UPDATE; // when you enter it should go to update and then keep updating
    }

    public virtual void Update()
    {
        stage = EVENT.UPDATE;
    }

    public virtual void Exit()
    {
        stage = EVENT.EXIT;
    }

    public GameState process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if(stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }

        return this;
    }
}

public class Play: GameState
{
    public Play() : base()
    {
        name = STATE.PLAY;
        stage = EVENT.ENTER;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        //GameManager logic goes here
        //updated every frame

        gameManager.entityAction();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
