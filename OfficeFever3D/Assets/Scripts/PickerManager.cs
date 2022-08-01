using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerManager : MonoBehaviour
{
    public List<GameObject> paperList = new List<GameObject>();
    public GameObject paperPrefab;

    public Transform collectPoint;
    int paperLimit =10 ;


    private void OnEnable()
    {
        TriggerEventManager.OnPaperCollect += GetPaper;
        TriggerEventManager.OnPaperGive += GivePaper ;
    }
    private void OnDisable()
    {
        TriggerEventManager.OnPaperCollect -= GetPaper;
        TriggerEventManager.OnPaperGive -= GivePaper ;
    }
    void GetPaper()
    {
        if(paperList.Count <= paperLimit)
        {
            GameObject temp = Instantiate(paperPrefab, collectPoint);
            temp.transform.position = new Vector3(collectPoint.position.x, 0.5f +  (float)paperList.Count/20,collectPoint.position.z );
            paperList.Add(temp);
            if(TriggerEventManager.printerManager != null)
            {
                 TriggerEventManager.printerManager .RemoveLast();  
            }
        }
    }
     public void RemoveLast()
    {
        if(paperList.Count > 0 )
        {
            Destroy(paperList[(paperList.Count-1)]);
            paperList.RemoveAt(paperList.Count-1);

        }
    }
    public void GivePaper()
    {
        if(paperList.Count > 0)
        {
            TriggerEventManager.workerManager.GetPaper();
            RemoveLast();
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
