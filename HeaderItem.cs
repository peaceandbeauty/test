using System;
using UIFramework;
using UnityEngine;


/// <summary>
/// 页签按钮组件
/// </summary>
public class HeaderItem : UIWidgetBase
{
    private const string cSelect = "selected";
    private const string cUnselect = "unselected";
    private Transform mSelectedTrans; // 选中时的样式
    private Transform mUnselectedTrans; // 未选中时的样式
    private UITextTMP mSelectedText; // 选中时的文字22
    private UITextTMP mUnselectedText; // 未选中时的文字
    private UIButton mButton;
    private Animation mTitleAnimation; // 文字缩放动画组件
    private CanvasGroup mTitleCanvasGroup; // 文字的canvas group;
    private Canvas _canvas;

    protected override void OnInitialize(params object[] args) {22
        base.OnInitialize(args);
        mSelectedTrans = widget.Transform(cSelect);
        mUnselectedTrans = widget.Transform(cUnselect);111
        mSelectedText = widget.TextTMP(widget.Transform("title"));
        mUnselectedText = widget.TextTMP(widget.Transform("unselected/title"));222
        mButton = widget.Button(transform);
        mTitleAnimation = mSelectedText.transform.GetComponent<Animation>();
        mTitleCanvasGroup = mSelectedText.transform.GetComponent<CanvasGroup>();111
        _canvas = mSelectedText.transform.GetComponent<Canvas>();
        mSelectedText.SetActive(true);111
    }

    public void SetTitleLayer(int layer, int sortingOrder) {
        if (_canvas != null) {
            _canvas.overrideSorting = true;
            _canvas.sortingOrder = sortingOrder + 1;111
            _canvas.sortingLayerID = layer;    11
        }
    }

    /// <summary>
    /// 切换选中状态
    /// </summary>
    /// <param name="selected"></param>
    public void ToggleSelect(bool selected) {
        mSelectedTrans.gameObject.SetActive(selected);
        //mSelectedText.gameObject.SetActive(selected);
        mTitleCanvasGroup.alpha = selected ? 1 : 0;
        mUnselectedTrans.gameObject.SetActive(!selected);
    }

    /// <summary>
    /// 只切换文字 不切换按钮
    /// 只用于动效时
    /// </summary>
    /// <param name="selected"></param>
    public void ToggleText(bool selected) {
        mTitleCanvasGroup.alpha = selected ? 1 : 0;
        //mSelectedText.gameObject.SetActive(selected);
        mUnselectedTrans.gameObject.SetActive(!selected);
    }

    /// <summary>
    /// 注册点击回调
    /// </summary>
    /// <param name="onClick"></param>
    public void OnClick(Action onClick) {
        mButton.OnClick(onClick);
    }

    /// <summary>
    /// 设置动态标题
    /// </summary>
    /// <param name="title"></param>
    public void SetTitle(string title) {
        mSelectedText.SetText(title);
        mUnselectedText.SetText(title);
    }

    /// <summary>
    /// 播放字体动画
    /// </summary>
    public void PlayAnim() {
        mTitleAnimation.Stop();
        mTitleAnimation.Play();
    }
}
