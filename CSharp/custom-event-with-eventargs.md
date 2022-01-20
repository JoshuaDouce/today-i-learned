# Custom event with custom event args

```
public class Worker
    {
        public event EventHandler<WorkPerformedEventArgs>? WorkPerformed;

        public virtual void DoWork(int hours)
        {
            OnWorkPerformed(hours);//Do work and notify
        }

        protected virtual void OnWorkPerformed(int hours)
        {
            if (WorkPerformed is EventHandler<WorkPerformedEventArgs> del) //Listeners attatched?
            {
                del(this, new WorkPerformedEventArgs { Hours = 1, WorkType = "" });//Raise event
            }
        }
    }

    public class WorkPerformedEventArgs : EventArgs
    {
        public int Hours { get; set; }
        public string WorkType { get; set; } = string.Empty;
    }
```
