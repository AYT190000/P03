using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLight : MonoBehaviour
{
    [Header("General Info")]
    [SerializeField]
    private string _name;

    [SerializeField]
    private HighLightType _highlightType = HighLightType.None;
    
    [Header("Description")]
    [SerializeField][Tooltip("Description of the object")]
    [TextArea()]
    private string _description;


}
