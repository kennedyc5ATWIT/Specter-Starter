using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;

    void Awake() // hen script is instanced, make sure it only happens once
    {
        if(_instance == null)
        {
            _instance = this;
        } else
        {
            Destroy(this);
        }
    }

    public GameManager instance()
    {
        return _instance;
    }




    private GameState state;
    public Player player;


    // Start is called before the first frame update
    void Start()
    {
        state = new Play();
    }

    // Update is called once per frame
    void Update()
    {
        state = state.process();
    }


    //called every update frame from the state machine
    public void entityAction()
    {
        //move the player,bosses,enemies,handle attacks, etc
        player.move();
    }
}
