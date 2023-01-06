using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

public class AnimatorCheck : MonoBehaviour
{
    public Animator animator;
  


    // Start is called before the first frame update
    void Start()

    {

        if (animator != null)
        {
            //AnimationClip cannonAnim = animator.runtimeAnimatorController.animationClips.FirstOrDefault(a => a.name == "Cannon");
            //AnimationEvent[] animationEvents = cannonAnim.events;
            //AnimationEvent firstEvent = animationEvents[0];



            //firstEvent.objectReferenceParameter = _useSkillRequirements;
            //animationEvents = cannonAnim.events;
            //List<AnimationEvent> updatedAnimationEvents = new List<AnimationEvent>();
            //updatedAnimationEvents.Add(firstEvent);
            //cannonAnim.events = updatedAnimationEvents.ToArray();
            //animator.Play("Cannon", 0, 0.0f);
        }

    }
    public void novoTeste() { }

    // Update is called once per frame
    void Update()
    {
        
    }
}
