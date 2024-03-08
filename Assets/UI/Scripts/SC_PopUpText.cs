using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SC_PopUpText : MonoBehaviour
{
    public float text;

    [SerializeField]
    float duration = 2f;
    void Awake(){
        var tmpui = gameObject.GetComponent<TextMeshProUGUI>();
        tmpui.color = new Color(0f,1f,0f);
        if(text < 0) tmpui.color = new Color(1f,0f,0f);
        tmpui.text = text.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


    float timePassed = 0f; 
    // Update is called once per frame
    void Update()
    {
        if (timePassed >= duration) Destroy(gameObject);
        timePassed += Time.deltaTime;
        transform.Translate(Vector3.up *Time.deltaTime);
    }
}
