using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIAttachmentBehaviour : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text currentParentText;
    // Start is called before the first frame update


    private void Start()
    {
        AttachmentBehaviour.AttachmentEvent.AddListener(lb =>
        {
            var lbTransform = lb.transform;
            nameText.text = "Name: " + lbTransform.name;
            statusText.text = "Attached? " + lb.Attached;
            currentParentText.text = lbTransform.parent == null ? "null parent" : "Current Parent: " + lbTransform.parent.name;

        });
    }
}
