using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    //重複してフェードしないために状態を管理します
    enum State
    {
        Wait,
        Fade
    }

    State state = State.Wait;
    private Image image;
    private Canvas canvas;
    
    private readonly int CANVAS_SORT_ORDER = 1000;

    void Awake()
    {
        //スクリプトからCanvasとImageを生成
        canvas = gameObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = CANVAS_SORT_ORDER;
        
        var scaler = gameObject.AddComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = Vector2.one;
        
        var obj = new GameObject("Image");
        obj.transform.SetParent(transform, false);
        image = obj.AddComponent<Image>();
        image.color = new Color(0, 0, 0, 255);
        
    }

    //外のクラスからフェード時間を指定して呼び出して使います
    //フェードイン
    public void Fadein(float span)
    {
        if (state == State.Wait)
        {
            state = State.Fade;
            StartCoroutine("ToTransparency", span);
        }
    }

    //フェードアウト
    public void Fadeout(float span)
    {
        if (state == State.Wait)
        {
            state = State.Fade;
            StartCoroutine("ToBlack", span);
        }
    }
    
    private IEnumerator ToBlack(float span)
    {
        float deltatime = 0;
        while (deltatime <= span)
        {
            deltatime += Time.deltaTime;
            image.color = new Color(0, 0, 0, deltatime/span);
            yield return null;
        }
        state = State.Wait;
    }

    private IEnumerator ToTransparency(float span)
    {
        float deltatime = span;
        while (deltatime >= 0)
        {
            deltatime -= Time.deltaTime;
            Debug.Log(deltatime);
            image.color = new Color(0, 0, 0, deltatime / span);
            yield return null;
        }
        state = State.Wait;
    }
    
}
