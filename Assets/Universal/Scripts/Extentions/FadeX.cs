using UnityEngine;
using DG.Tweening;

public static class FadeX
{
    /// <summary>
/// Fade a Canvas group
/// </summary>
/// <param name="_cvg">the canvas group to fade</param>
/// <param name="_toValue">The value to fade to</param>
/// <param name="_duration">How long the fade lasts</param>
    public static void FadeCanvas(CanvasGroup _cvg, float _toValue, float _duration)
    {
        _cvg.DOFade(_toValue, _duration);
    }
}
