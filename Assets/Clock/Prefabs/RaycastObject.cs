
using UnityEngine;

public class RaycastObject : MonoBehaviour {

    //for raycast
    public virtual void OnRaycastEnter(RaycastHit hitInfo)
    {
        Debug.LogFormat("Raycast entered on {0}", gameObject.name);
    }

    public virtual void OnRayCast(RaycastHit hitInfo)
    {   
        Debug.LogFormat("Raycast stayed on {0}", gameObject.name);

    }

    public virtual void OnRaycastExit()
    {
        Debug.LogFormat("Raycast exited on {0}", gameObject.name);
        TurnOffMessage();
    }

    //for hintBox
    [SerializeField]
    Canvas messageCanvas;

    protected CanvasGroup cg;
    protected bool messageOn;
    public bool haveSeenMsg;

    protected void Start()
    {
        Debug.LogFormat("Hello {0}", this.name);
        cg = messageCanvas.GetComponent<CanvasGroup>();
        cg.alpha = 0f;
        messageOn = false;
        haveSeenMsg = false;
    }

    public void TurnOnMessage()
    {
        messageOn = true;
        haveSeenMsg = true;
    }

    public void TurnOffMessage()
    {
        messageOn = false;
    }

    protected void Update()
    {
        if (messageOn && cg.alpha < 1)
            cg.alpha += Time.deltaTime * 1.5f;
        else if (!messageOn && cg.alpha > 0)
            cg.alpha -= Time.deltaTime * 1.5f;
    }


}
