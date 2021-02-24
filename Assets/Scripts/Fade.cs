using UnityEngine;

public class Fade : MonoBehaviour
{
    public float FadeInTime;
    public float FadeWaitTime;
    public float FadeOutTime = 1;
    public bool DestroyOnFadeOut;
    private CanvasGroup[] _canvasGroups;

    private Renderer[] _renderers;

    private State FadeState { get; set; }
    private float FadeTimer { get; set; }

    public float Alpha
    {
        get
        {
            switch (FadeState)
            {
                case State.FadeIn:
                    return 1.0f - FadeTimer / FadeInTime;
                case State.FadeOut:
                    return FadeTimer / FadeOutTime;
            }

            return 1.0f;
        }
    }

    private void Start()
    {
        _renderers = gameObject.GetComponentsInChildren<Renderer>();
        _canvasGroups = gameObject.GetComponentsInChildren<CanvasGroup>();

        StartFade();
    }

    private void Update()
    {
        if (FadeState == State.Done)
            return;

        FadeTimer -= Time.deltaTime;
        if (FadeTimer <= 0)
            OnFadeDone();

        UpdateAlpha();
    }

    private void UpdateAlpha()
    {
        var alpha = Alpha;

        foreach (var renderer in _renderers)
        {
            var color = renderer.material.color;
            renderer.material.color = color.WithAlpha(alpha);
        }

        foreach (var canvasGroup in _canvasGroups) canvasGroup.alpha = alpha;
    }

    private void OnFadeDone()
    {
        switch (FadeState)
        {
            case State.FadeIn:
            {
                FadeTimer = FadeWaitTime;
                FadeState = State.Wait;
            }
                break;
            case State.Wait:
            {
                FadeTimer = FadeOutTime;
                FadeState = State.FadeOut;
            }
                break;
            case State.FadeOut:
            {
                if (DestroyOnFadeOut)
                    Destroy(gameObject);

                StopFade();
            }
                break;
        }
    }

    public void StartFade()
    {
        enabled = true;

        if (FadeInTime > 0)
        {
            FadeTimer = FadeInTime;
            FadeState = State.FadeIn;
        }
        else
        {
            FadeTimer = FadeOutTime;
            FadeState = State.FadeOut;
        }
    }

    public void StopFade()
    {
        enabled = false;
        FadeTimer = 0.0f;
        FadeState = State.Done;
    }

    private enum State
    {
        FadeIn,
        Wait,
        FadeOut,
        Done
    }
}