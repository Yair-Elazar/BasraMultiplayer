using UnityEngine;
using DG.Tweening;
public class StartGameCommand : Command
{
    public override void Execute()
    {
        var panelCG = GameObject.Find("StartGamePanel").GetComponent<CanvasGroup>();
        var sequence = DOTween.Sequence();
        sequence.Append(panelCG.DOFade(1f, 1f));
        sequence.AppendInterval(2f);
        sequence.Append(panelCG.DOFade(0f, 1f));
        sequence.OnComplete(ExecuteComplete);
    }
}
