using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Skill", menuName = "Skill")]
public class Letters : Interactable
{


    //[SerializeField] bool _isDante = false;//if this letter is from dante or joshua
    //protected UiManager ui_uiManager;
    [SerializeField] protected bool _isDante = false;//if this letter is from dante or joshua
    protected bool _canInteract = false;
    [SerializeField] protected string _letter_content_string;

    private void Start()
    {
        ui_uiManager = GameObject.Find("UI Manager").GetComponent<UiManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (cc_player)
        {
            if (cc_player.GetComponent<PlayerInput>().GetIsInteracting())
            {
                if (_isDante)
                {
                    ui_uiManager.SetDanteText(_letter_content_string);
                    ui_uiManager.SetIsDanteLetterDisplayOn(true);
                }
                else
                {
                    ui_uiManager.SetJoshuaText(_letter_content_string);
                    ui_uiManager.SetIsJoshuaLetterDisplayOn(true);
                }
                cc_player.GetComponent<PlayerInput>().SetIsInteracting(false);
                Destroy(gameObject);
            }
        }
    }
}
