# Lambda Event Handler

```
var worker = new Worker();
worker.WorkPerformed += (s, e) =>
{
    Console.WriteLine("Worked: " + e.Hours + " hour(s) doing: " + e.WorkType);
    Console.WriteLine("Some other value");
};
```
