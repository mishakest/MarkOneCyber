using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Info")]
    public string CharacterName;
    public int Cost;

    [Header("Unity Components")]
    public Animator Animator;
    public Sprite Icon;

    [Header("Sound")]
    public AudioClip JumpSound;
    public AudioClip HitSound;
    public AudioClip DeathSound;
}
