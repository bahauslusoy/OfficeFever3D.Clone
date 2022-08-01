using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventManager : MonoBehaviour
{
    public delegate void OnCollectArea();
    public static event OnCollectArea OnPaperCollect;
    public delegate void OnDeskArea();
    public static event OnDeskArea OnPaperGive;
    public static WorkerManager workerManager;

    public delegate void OnMoneyArea();
    public static event OnMoneyArea OnMoneyCollect;
    bool isGiving;

    bool isCollecting;
    public static PrinterManager printerManager;
    void Start()
    {
        StartCoroutine(CollectEnum());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator CollectEnum()
    {
        while (true)
        {
            if (isCollecting == true)
            {
                OnPaperCollect();
            }
            if (isGiving == true)
            {
                OnPaperGive();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = true;
            printerManager = other.gameObject.GetComponent<PrinterManager>();
        }
        if (other.gameObject.CompareTag("WorkArea"))
        {
            isGiving = true;
            workerManager = other.gameObject.GetComponent<WorkerManager>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = false;
            printerManager = null;
        }
        if (other.gameObject.CompareTag("WorkArea"))
        {
            isGiving = false;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Money"))
        {
            OnMoneyCollect();
            Destroy(other.gameObject);
        }
    }
}
