using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HCB.Core;
using HCB.Utilities;

public class CharacterManager : Singleton<CharacterManager> 
{
   // private List<GameObject> _aiList = new List<GameObject>();


   // public void AddToAIList(GameObject Ai)
   // {
   //     _aiList.Add(Ai);
   // }

   // public void RemoveFromAIlist(GameObject Ai)
   // {
   //     _aiList.Remove(Ai);
   // }
    
   ////fonksiyon getclosestAi transform parametresi alacak player, Ai listesini for ile donecegim en yakini bulmak icin.
   // public GameObject GetClosestAI(Transform player)
   // {
   //     float maxDist = Mathf.Infinity;
   //     GameObject closestAI = null;

   //     for (int i = 0; i < _aiList.Count; i++)
   //     {
   //         float dist = Vector3.Distance(player.position, _aiList[i].transform.position);

   //         if(dist < maxDist)
   //         {
   //             closestAI = _aiList[i];
   //         }


   //         return closestAI;
   //     }
   // }

}
