using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI scoreTmp;


   private void Start()
   {
      RefreshText();
   }

   public void RefreshText()
   {
      scoreTmp.text = $"Score\n{ScoreManager.Instance.score}";
   }
}
