using System;
using System.Collections;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField] private Animator animator;

    protected string playerID = "";

    private PlayerGroup playerGroup;
    private PawnMover pawnMover;

    private string username;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        playerGroup = GetComponent<PlayerGroup>();
        pawnMover = GetComponent<PawnMover>();
    }

    public void MovePawn(int amountToMove)
    {
        pawnMover.MovePawn(amountToMove);
    }

    public void MovePawnDirectlyToTile(SmartTile tileToMoveTo)
    {
        if (pawnMover != null)
        {
            pawnMover.MovePawnDirectlyToTile(tileToMoveTo);
        }
    }

    public void SetID(string playerID)
    {
        if (this.playerID == "")
        {
            this.playerID = playerID;
        }
    }

    public void SetUserName(string username)
    {
        this.username = username;
    }

    public string PlayerID { get => playerID;}
    public Animator Animator { get => animator; }
    public string Username { get => username;  }
    public PawnMover PawnMover { get => pawnMover; }
}