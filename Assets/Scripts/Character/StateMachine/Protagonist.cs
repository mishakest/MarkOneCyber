using UnityEngine;
using MarkOne.StateMachine;

public class Protagonist : Actor<Protagonist>
{
    public Character Character;
    public override Animator Animator => Character.Animator;
}
