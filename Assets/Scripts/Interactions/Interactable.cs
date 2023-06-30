using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Interactable : MonoBehaviour
{

    [SerializeField]protected Canvas item_canvas;
    //public TextMeshProUGUI _text_letter;
    public string _letter_content_string;

    // Start is called before the first frame update
    void Start()
    {
        item_canvas = transform.GetChild(0).GetComponent<Canvas>();
        item_canvas.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        item_canvas.transform.GetChild(0).gameObject.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        item_canvas.transform.GetChild(0).gameObject.SetActive(false);
    }
}
