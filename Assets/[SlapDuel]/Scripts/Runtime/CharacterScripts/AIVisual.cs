using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIVisual : MonoBehaviour
{
    private SkinnedMeshRenderer _enemyMat;
    public SkinnedMeshRenderer SkinnedMeshRenderer { get { return _enemyMat == null ? _enemyMat = GetComponentInChildren<SkinnedMeshRenderer>() : _enemyMat; } }

    private Color _startColor = Color.white;
    private Color _endColor = Color.red;
    

    public void ChangeSlapColor(float time)
    {
        SkinnedMeshRenderer.materials[1].color = Color.Lerp(SkinnedMeshRenderer.materials[1].color, _endColor, 0.2f);
    }
}


