using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RulesUI : MonoBehaviour
{
    public Action onClose;

    // Start is called before the first frame update
    void Start()
    {
        Transform panelTransform = transform.Find("Panel");
        Transform closeButtonTransform = panelTransform.Find("Close Button");
        Button closeButton = closeButtonTransform.GetComponent<Button>();

        closeButton.onClick.AddListener(OnCloseButtonClick);

        
        
    }

    void OnCloseButtonClick()
    {
        gameObject.SetActive(false);
        onClose.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
