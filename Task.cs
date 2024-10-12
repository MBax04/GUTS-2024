public class Task{
    public string taskName;
    public float completedness;
    TaskList taskList;

    public Task(string taskName, float completedness){
        this.taskName = taskName;
        this.completedness = completedness;
    }

    public void completeTask(Task task){
        task.setCompletedness(1);
    }

    public void setCompletedness(float completedness){
        //if this gets set to 1, call taskList.completeTask(this) 
        //this.completedness = completedness;
        if (completedness == 1){
            taskList.completeTask(this);
        }

    }

    public string getTaskName(){
        return taskName;
    }

    public float getCompletedness(){
        return completedness;
    }
}