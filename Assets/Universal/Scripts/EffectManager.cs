using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

public class EffectManager : GameBehaviour<EffectManager>
{
    public Volume volume;
    private ChromaticAberration aberration;
    private Bloom bloom;
    private Vignette vignette;

    #region Chromatic
    public void SetChromatic(float _value)
    {
        volume.profile.TryGet(out aberration);
        aberration.intensity.value = _value;
    }
    #endregion

    public void TweenChromaticInOut(float _intensity, float _duration)
    {
        volume.profile.TryGet(out aberration);
        DOTween.To(() => aberration.intensity.value, (x) => aberration.intensity.value = x, _intensity, _duration).
            OnComplete(() => TweenChromatic(0, _duration));
    }

    public void TweenChromatic(float _intensity, float _duration)
    {
        volume.profile.TryGet(out aberration);
        DOTween.To(() => aberration.intensity.value, (x) => aberration.intensity.value = x, _intensity, _duration);
    }

    public void SetBloom(float intensity)
    {
        volume.profile.TryGet(out bloom);
        bloom.intensity.value = intensity;
    }

    #region Vignette
    public void SetVignette(float _intensity)
    {
        volume.profile.TryGet(out vignette);
        vignette.intensity.value = _intensity;
    }

    public void TweenVignetteInOut(float _intensity, float _duration)
    {
        volume.profile.TryGet(out vignette);
        DOTween.To(() => vignette.intensity.value, (x) => vignette.intensity.value = x, _intensity, _duration).
            OnComplete(() => TweenVignette(0, _duration));
    }

    public void TweenVignette(float _intensity, float _duration)
    {
        volume.profile.TryGet(out vignette);
        DOTween.To(() => vignette.intensity.value, (x) => vignette.intensity.value = x, _intensity, _duration);
    }
    #endregion
}
