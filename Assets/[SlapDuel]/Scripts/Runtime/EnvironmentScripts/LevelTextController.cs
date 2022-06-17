using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTextController : MonoBehaviour
{
    private TextMeshProUGUI _text;

    public TextMeshProUGUI Text { get { return _text == null ? _text = GetComponent<TextMeshProUGUI>() : _text; } }

    public void SetLevel(int level)
    {
        Text.SetText("Lv. " + level);
    }
}
