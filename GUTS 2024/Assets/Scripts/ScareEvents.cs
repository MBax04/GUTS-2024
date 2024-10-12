using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ScareEvents : MonoBehaviour
{
    (string eventType, double eventProbability) [] eventProbabilities = new [] { 
        ("TEXT", 0.20),
        ("SOUND", 0.3),
        ("PHONE", 0.5),
        ("LIGHTING_INTENSE", 0.75),
        ("LIGHTING_OFF", 1)
    };
    string[] scaryStrings = {"THEY LIVE IN THE WALLS", "I'M WATCHING YOU", "BOOO", "THERE'S NOTHING BUT DEATH", "blood"};
    string[] scarySounds = {"scream", "scream2", "modem"};
    float nextEventDue = -1;
    float disableEventInProgressAt = -1;
    string eventInProgress = "NONE";
    public Canvas textScareCanvas;
    public TMP_Text scareTextObj;
    public Light2D playerLight;
    void updateTimer() {
        nextEventDue = Time.realtimeSinceStartup + Random.Range(30f, 150.0f);
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
        if (eventInProgress != "NONE") {
            if (disableEventInProgressAt != -1 && Time.realtimeSinceStartup >= disableEventInProgressAt) {
                if (eventInProgress == "TEXT") {
                    playerLight.pointLightInnerRadius = 3;
                    textScareCanvas.enabled = false;
                    updateTimer();
                    disableEventInProgressAt = -1;
                    eventInProgress = "NONE";
                } else if (eventInProgress.StartsWith("LIGHTING_")) {
                    playerLight.pointLightInnerRadius = 3;
                    playerLight.intensity = 1;
                    updateTimer();
                    disableEventInProgressAt = -1;
                    eventInProgress = "NONE";
                }
            }
        } else if (nextEventDue != -1 && Time.realtimeSinceStartup > nextEventDue) {
            float randomEventProbability = Random.Range(0f, 1f);
            string eventType = "NONE";
            foreach ((string eventType, double eventProbability) eventProbability in eventProbabilities) {
                if (randomEventProbability <= eventProbability.eventProbability) {
                    eventType = eventProbability.eventType;
                    break;
                }
            }

            if (eventType == "TEXT") {
                eventInProgress = eventType;
                disableEventInProgressAt = Time.realtimeSinceStartup + Random.Range(1f, 5.0f);
                scareTextObj.SetText(scaryStrings[Random.Range(0, scaryStrings.Length)]);
                textScareCanvas.enabled = true;
            } else if (eventType.StartsWith("LIGHTING_")) {
                eventInProgress = eventType;
                if (eventType == "LIGHTING_INTENSE") {
                    playerLight.pointLightInnerRadius = 8;
                    playerLight.intensity = 65;
                } else if (eventType == "LIGHTING_OFF") {
                    playerLight.pointLightInnerRadius = 0;
                    playerLight.intensity = 0;
                }
                disableEventInProgressAt = Time.realtimeSinceStartup + Random.Range(3f, 15.0f);
            } else if (eventType == "SOUND") {
                AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("UI Assets/" + scarySounds[Random.Range(0, scarySounds.Length)]), Camera.main.transform.position);
                updateTimer();
            } else if (eventType == "PHONE") {
                AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("UI Assets/phone"), Camera.main.transform.position);
                updateTimer();
            }
        }
    }
}
