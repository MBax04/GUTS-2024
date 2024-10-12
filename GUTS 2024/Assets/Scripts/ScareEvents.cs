using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;

public class ScareEvents : MonoBehaviour
{
    string[] scaryStrings = {"THEY LIVE IN THE WALLS", "I'M WATCHING YOU", "BOOO", "THERE'S NOTHING BUT DEATH", "blood"};
    float nextEventDue = -1;
    float disableScareTextAt = -1;
    bool eventInProgress = false;
    public Canvas textScareCanvas;
    public TMP_Text scareTextObj;
    void updateTimer() {
        nextEventDue = Time.realtimeSinceStartup + Random.Range(60f, 300.0f);
        Debug.Log("Set for: " + nextEventDue.ToString());
    }
    // Start is called before the first frame update
    void Start()
    {
        updateTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (disableScareTextAt != -1 && Time.realtimeSinceStartup >= disableScareTextAt) {
            textScareCanvas.enabled = false;
            updateTimer();
            disableScareTextAt = -1;
            Debug.Log("off!");
            eventInProgress = false;
        }
        if (nextEventDue != -1 && Time.realtimeSinceStartup > nextEventDue && !eventInProgress) {
            eventInProgress = true;
            Debug.Log("on!");
            disableScareTextAt = Time.realtimeSinceStartup + Random.Range(1f, 5.0f);
            scareTextObj.SetText(scaryStrings[Random.Range(0, scaryStrings.Length)]);
            textScareCanvas.enabled = true;
        }
    }
}
