using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;

public class PlayerTorch : MonoBehaviour
{
    Light2D playerLight;
    float torchStartTime = -1;
    float currentTorchMaxTime = -1;
    public TMP_Text timerLabel;
    
    // Start is called before the first frame update
    void Start()
    {
        playerLight = GameObject.Find("SpotLight").GetComponent<Light2D>();
        torchRecharge();
    }

    public void torchRecharge(float torchMaxTime = 10) {
        torchStartTime = Time.realtimeSinceStartup;
        currentTorchMaxTime = torchMaxTime;
        playerLight.pointLightInnerRadius = 3;
        playerLight.pointLightOuterRadius = 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (torchStartTime >= 0) {
            float timeElapsed = Time.realtimeSinceStartup - torchStartTime;
            float timeLeft = currentTorchMaxTime - timeElapsed;
            timerLabel.SetText("Torch "+ Mathf.Round(timeLeft)+"s");

            // Debug.Log(timeLeft);
            playerLight.intensity = 3f + Random.Range(-0.5f, 0.5f);

            if (timeLeft <= 5 && timeLeft >= 0) {
                playerLight.pointLightInnerRadius = 3f * (timeLeft / 5f);
                playerLight.pointLightOuterRadius = (4f * (timeLeft / 5f)) + 4;
            } else if (timeLeft <= 0) {
                timerLabel.SetText("");
                playerLight.pointLightInnerRadius = 0;
                playerLight.pointLightOuterRadius = 4;
                torchStartTime = -1; // Indicates torch not currently working
            }
        }
    }
}
