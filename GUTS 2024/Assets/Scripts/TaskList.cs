using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TaskList : MonoBehaviour
{
    public List<Task> tasks = new List<Task>();
    private int taskCount = 0;
    public int level = 1;

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
    public RawImage task1indicator;
    public RawImage task2indicator;
    public RawImage task3indicator;
    public RawImage task4indicator;
    private RawImage[] indicators;
    // Start is called before the first frame update
    void Start()
    {
        TMP_Text[] _taskTexts = {task1text, task2text, task3text, task4text};
        taskTexts = _taskTexts;

        RawImage[] _indicators = {task1indicator, task2indicator, task3indicator, task4indicator};
        indicators = _indicators;
        
        task1text.SetText("");
        task2text.SetText("");
        task3text.SetText("");
        task4text.SetText("");
        task1indicator.texture = Resources.Load<Texture>("UI Assets/transparent");
        task2indicator.texture = Resources.Load<Texture>("UI Assets/transparent");
        task3indicator.texture = Resources.Load<Texture>("UI Assets/transparent");
        task4indicator.texture = Resources.Load<Texture>("UI Assets/transparent");

        if (level == 1) {
            addTask(new Task("Collect all treasure", 0.0f));
        } else if (level == 2) {
            addTask(new Task("Collect all treasure", 0.0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
