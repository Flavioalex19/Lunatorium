using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    Stats cc_Stats_Player;

    #region Letter Variables
    #region Letters Texts
    [SerializeField]TextMeshProUGUI _text_DanteLetter;
    [SerializeField]TextMeshProUGUI _text_JoshuaLetter;
    #endregion
    [SerializeField] Animator animator_ui_letter_Dante;
    [SerializeField] Animator animator_ui_letter_Joshua;
    [SerializeField] bool _IsDanteLetterDisplayOn = false;
    [SerializeField] bool _IsJoshuaLetterDisplayOn = false;
    #region Buttons
    [SerializeField]Button btn_closeLetterDante;
    [SerializeField]Button btn_closeLetterJoshua;
    #endregion
    #region UI Player
    [SerializeField] Animator _anim_mindBar;
    [SerializeField] Image _ui_mindBar;
    bool _isMindBarActive = false;
    #endregion
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        cc_Stats_Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();

        btn_closeLetterDante.onClick.AddListener(() => SetIsDanteLetterDisplayOn(false));
        btn_closeLetterJoshua.onClick.AddListener(() => SetIsJoshuaLetterDisplayOn(false));
    }

    // Update is called once per frame
    void Update()
    {
        animator_ui_letter_Dante.SetBool("isOn", _IsDanteLetterDisplayOn);
        animator_ui_letter_Joshua.SetBool("isOn", _IsJoshuaLetterDisplayOn);
        _anim_mindBar.SetBool("isOn", _isMindBarActive);

        _ui_mindBar.fillAmount = cc_Stats_Player.GetCurrentMind() / cc_Stats_Player.GetMind();
    }
    #region Get & Set
    public bool GetIsDanteLetterDisplayOn()
    {
        return _IsDanteLetterDisplayOn;
    }
    public void SetIsDanteLetterDisplayOn(bool isDanteLetterDisplayOn)
    {
        _IsDanteLetterDisplayOn=isDanteLetterDisplayOn;
    }
    public bool IsJoshuaLetterDisplayOn() 
    {  
        return _IsJoshuaLetterDisplayOn;
    }
    public void SetIsJoshuaLetterDisplayOn(bool isJoshuaLetterDislayOn)
    {
        _IsJoshuaLetterDisplayOn=isJoshuaLetterDislayOn;
    }
    public void SetDanteText(string text)
    {
        _text_DanteLetter.text = text;
    }
    public void SetJoshuaText(string text)
    {
        _text_JoshuaLetter.text = text;
    }

    public bool GetisMindBarActive()
    {
        return _isMindBarActive;
    }
    public void SetIsMindBarActive(bool isMindBarActive)
    {
        _isMindBarActive=isMindBarActive;
    }
    #endregion
    
}
