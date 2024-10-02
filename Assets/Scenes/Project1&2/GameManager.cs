using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
  public int PointCollect = 0;
  
  public TextMeshProUGUI text;
  private void Awake()
  {
    if(Instance !=null && Instance!=this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
  }

  void Update()
  {
    text.text = PointCollect.ToString();
  }

}
