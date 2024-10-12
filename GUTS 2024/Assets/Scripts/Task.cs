using TMPro;
using UnityEngine;

public class Task{
    public const string TASK_TEXT_TEMPLATE = "[     ]    ";
    public string taskName;
    public float completedness;
    TaskList taskList;
    public TMP_Text taskTextObj;
    public SpriteRenderer indicator;

    public Task(string taskName, float completedness){
        this.taskName = taskName;
        this.completedness = completedness;
    }

    public void completeTask(Task task){
        task.setCompletedness(1);
    }

    public void setCompletedness(float completedness){
    }

    public string getTaskName(){
        return taskName;
    }

    public float getCompletedness(){
        return completedness;
    }

    public void updateIndicator() {
        if (completedness >= 1)
            indicator.sprite = Resources.Load("UI Assets/tick", typeof(Sprite)) as Sprite;
        else 
            indicator.sprite = Resources.Load("UI Assets/in-progress", typeof(Sprite)) as Sprite;
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