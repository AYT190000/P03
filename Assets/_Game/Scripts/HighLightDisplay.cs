using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class HighLightDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _highlightNameTextView;
    //[SerializeField] private TextMeshProUGUI _highlightDescriptionTextView;

    private Transform highlight;
    private Transform selection;
    private RaycastHit raycastHit;
    private HighLight _highlight;
    


    void Update()
    {
        if(highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {
            highlight = raycastHit.transform;
            if(highlight.CompareTag("Highlightable") && highlight != selection)
            {
                if (highlight.gameObject.GetComponent<Outline>() != null)
                {
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                }
                else
                {
                    Outline outline = highlight.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                    highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.yellow;
                    highlight.gameObject.GetComponent<Outline>().OutlineWidth = 8.0f;

                }

            }
            else
            {
                highlight = null;
            }
        }


        if(Input.GetMouseButtonDown(2))
        {
            if (highlight)
            {
                if (selection != null)
                {
                    selection.gameObject.GetComponent<Outline>().enabled = false;
                }
                selection = raycastHit.transform;
                selection.gameObject.GetComponent<Outline>().enabled = true;
                highlight = null;
                _highlightNameTextView.text = selection.gameObject.ToString();
                //_highlightDescriptionTextView.text = selection.gameObject._highlight.GetComponent<Description>;

            }
            else
            {
                if(selection)
                {
                    selection.gameObject.GetComponent<Outline>().enabled = false;
                    selection = null;
                    _highlightNameTextView.text = " ";
                }
            }
        }
    }
}
