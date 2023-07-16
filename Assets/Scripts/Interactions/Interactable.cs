using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Interactable : MonoBehaviour
{

    public Canvas item_canvas;
    //public TextMeshProUGUI _text_letter;
    /*
    [SerializeField]protected bool _isDante = false;//if this letter is from dante or joshua
    protected bool _canInteract = false;
    [SerializeField]protected string _letter_content_string;
    */

    //Protected Variables
    [SerializeField]protected Transform cc_player;//If the player is on the trigger

    protected UiManager ui_uiManager;

    // Start is called before the first frame update
    void Awake()
    {
        item_canvas = transform.GetChild(0).GetComponent<Canvas>();
        ui_uiManager = GameObject.Find("UI Manager").GetComponent<UiManager>();
        item_canvas = transform.GetChild(0).GetComponent<Canvas>();
        item_canvas.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void Update()
    {
        /*
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
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            cc_player = other.transform;
            item_canvas.transform.GetChild(0).gameObject.SetActive(true);
            cc_player.GetComponent<PlayerInput>().SetCanInteract(true);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        cc_player.GetComponent<PlayerInput>().SetCanInteract(false);
        cc_player = null;
        item_canvas.transform.GetChild(0).gameObject.SetActive(false);
        
    }
}
