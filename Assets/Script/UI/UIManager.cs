using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
  
    public void SetActiveAfterTime(GameObject obj)
    {
        obj.SetActive(false);
    }
    private IEnumerator ShowA(int time,GameObject obj)
    {
        yield return new WaitForSeconds(time);
        SetActiveAfterTime(obj);
    }

  
}
