using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Task{
    public const string TASK_TEXT_TEMPLATE = "[     ]    ";
    public string taskName;
    public float completedness;
    TaskList taskList;
    public TMP_Text taskTextObj;
    public RawImage indicator;

    public Task(string taskName, float completedness){
        this.taskName = taskName;
        this.completedness = completedness;
    }

    public void completeTask(){
        this.setCompletedness(1);
    }

    public void setCompletedness(float completedness){
        this.completedness = completedness;
        updateIndicator();
    }

    public string getTaskName(){
        return taskName;
    }

    public float getCompletedness(){
        return completedness;
    }

    public void updateIndicator() {
        Texture texture;
        if (completedness >= 1)
            texture = Resources.Load<Texture>("UI Assets/tick");
        else 
            texture = Resources.Load<Texture>("UI Assets/in-progress");

        Debug.Log(texture);
        Debug.Log(indicator.texture);
        
        indicator.texture = texture;
    }

    public void updateText() {
        string percent;
        if (completedness >= 1) {
            percent = "100%";
        } else {
            percent = (completedness * 100).ToString("0.##\\%");
        }
        taskTextObj.SetText(TASK_TEXT_TEMPLATE + this.taskName + "  (" + percent + ")");
    }
}