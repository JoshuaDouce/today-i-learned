# Raising custom event

```
public delegate void WorkPerformedHandler(int hours);
    public class Worker
    {
        public event WorkPerformedHandler? WorkPerformed;

        public virtual void DoWork(int hours)
        {
            OnWorkPerformed(hours);//Do work and notify
        }

        protected virtual void OnWorkPerformed(int hours)
        {
            if (WorkPerformed is WorkPerformedHandler del) //Listeners attatched?
            {
                del(hours);//Raise event
            }
        }
    }
```
