using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerAnimator : PlayerComponent
{
    [SerializeField] private Animator animator;

    [SerializeField] private Rig holdRig;
    [SerializeField] private GameObject holdParent;
    [SerializeField] private float holdBlendSpeed = 2f;
    [SerializeField] private AnimationCurve holdBeginCurve;
    [SerializeField] private AnimationCurve holdEndCurve;

    [SerializeField] private Rig trackRig;
    [SerializeField] private float trackBlendSpeed = 2f;
    [SerializeField] private AnimationCurve trackBeginCurve;
    [SerializeField] private AnimationCurve trackEndCurve;

    private void OnEnable()
    {
        level.Settings.Events.OnPaused += OnPaused;
        level.Settings.Events.OnResumed += OnResumed;
    }

    private void OnDisable()
    {
        level.Settings.Events.OnPaused -= OnPaused;
        level.Settings.Events.OnResumed -= OnResumed;
    }

    private void OnPaused()
    {
        StartCoroutine(PauseAnimation());
    }

    private void OnResumed()
    {
        StartCoroutine(BlendRigWeight(trackRig, 1f, 0f, trackBlendSpeed, trackEndCurve));
        StartCoroutine(BlendRigWeight(holdRig, 1f, 0f, holdBlendSpeed, holdEndCurve));
        holdParent.SetActive(false);
    }

    private IEnumerator BlendRigWeight(Rig rig, float from, float to, float speed, AnimationCurve curve, float delay = 0, Action onStart = null, Action onComplete = null)
    {
        yield return new WaitForSeconds(delay);

        onStart?.Invoke();

        float lerpTime = 0f;
        while (lerpTime < 1f)
        {
            rig.weight = curve.Evaluate(Mathf.Lerp(from, to, lerpTime));
            lerpTime += Time.deltaTime * speed;
            yield return null;
        }

        rig.weight = to;
        onComplete?.Invoke();
    }

    private IEnumerator PauseAnimation()
    {
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(BlendRigWeight(trackRig, 0f, 1f, trackBlendSpeed, trackBeginCurve));
        holdParent.SetActive(true);
        holdRig.weight = 1f;
        yield return new WaitForSeconds(0.8f);
        animator.SetTrigger("Swing");
    }
}
