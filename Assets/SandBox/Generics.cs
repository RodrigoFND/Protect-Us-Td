using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Generics 
{
   public static float CalculateAnimationSpeed(int playerAttackSpeed,int skillAttackSpeed)
    {
        float playerAtkSpeed = (float)(playerAttackSpeed * 0.010);
        float skillAtkSpeed = (float)(skillAttackSpeed * 0.010);
        return playerAtkSpeed + skillAtkSpeed;
    }
    public static AnimationClip GetAnimationClip(Animator animator, string animationClipName)
    {
        var clips = animator.runtimeAnimatorController.animationClips.ToList();
        AnimationClip animation = clips.FirstOrDefault(a => a.name == animationClipName);
        return animation;
    }

    public static bool AnimationIsPlaying(Animator animator,string stateName)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
}
