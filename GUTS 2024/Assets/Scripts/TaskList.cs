using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskList : MonoBehaviour
{
    public List<Task> tasks = new List<Task>();
    private int taskCount = 0;

    public void addTask(Task task){
        if (taskCount < 4) {
            tasks.Add(task);
            task.taskTextObj = taskTexts[taskCount];
            task.indicator = indicators[taskCount];
            taskCount++;
            task.updateText();
            task.updateIndicator();
        } else {
            Debug.LogWarning("Trying to add more than 4 tasks!");
        }
    }

    public TMP_Text task1text;
    public TMP_Text task2text;
    public TMP_Text task3text;
    public TMP_Text task4text;
    
    private TMP_Text[] taskTexts;
    public SpriteRenderer task1indicator;
    public SpriteRenderer task2indicator;
    public SpriteRenderer task3indicator;
    public SpriteRenderer task4indicator;
    private SpriteRenderer[] indicators;
    // Start is called before the first frame update
    void Start()
    {
        TMP_Text[] _taskTexts = {task1text, task2text, task3text, task4text};
        taskTexts = _taskTexts;

        SpriteRenderer[] _indicators = {task1indicator, task2indicator, task3indicator, task4indicator};
        indicators = _indicators;
        
        task1text.SetText("");
        task2text.SetText("");
        task3text.SetText("");
        task4text.SetText("");
        task1indicator.sprite = null;
        task2indicator.sprite = null;
        task3indicator.sprite = null;
        task4indicator.sprite = null;

        addTask(new Task("Collect all treasure", 0.4f));
        addTask(new Task("Restore sanity", 1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
