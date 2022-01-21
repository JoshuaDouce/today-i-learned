# Example of the Mediator pattern

```
internal sealed class Mediator
    {
        //Singleton
        private static readonly Mediator _instance = new Mediator();
        private Mediator() {}

        public static Mediator GetInstance()
        {
            return _instance;
        }

        //Event to subscribed to
        public event EventHandler<JobChangedEventArgs> JobChanged;

        public void OnJobChanged(object sender, Job job)
        {
            //delegate
            var jobChanged = JobChanged;
            if (jobChanged != null)
            {
                //Event raiser
                jobChanged(sender, new JobChangedEventArgs { Job = job });
            }
        }
    }
```
