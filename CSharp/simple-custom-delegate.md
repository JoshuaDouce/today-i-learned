# Simple custom delegate

```
WorkPerformedHandler del1 = new(WorkPerformed);
WorkPerformedHandler del2 = new(WorkPerformed3);

del1 += WorkPerformed2;
DoWork(del1);

del2 += del1;
DoWork(del2);

Console.Read();

static void DoWork(WorkPerformedHandler del)
{
    del(1, "");
}

static void WorkPerformed(int hours, string workType)
{
    Console.WriteLine("Work performed one called");
};

static void WorkPerformed2(int hours, string workType)
{
    Console.WriteLine("Work performed two called");
};

static void WorkPerformed3(int hours, string workType)
{
    Console.WriteLine("Work performed three called");
};

public delegate void WorkPerformedHandler(int hours, string workType);
```
