# Using simple callbacks

Simple example of making use of a callback in react to pass data up and down the component tree. 

Pass function down component tree </br>
Component A -> Component B -> Component C </br>
Component C calls passed function </br>
When component A finishes executing function callBack function is called </br>
Component C executes callback function.

Function with callback function as parameter defined at the top level. passed to child component with callback as a parameter.
```
function ComponentA(){
    const [counter, setCounter] = useState(0);

    function updateCount(doneCallback){
        await someFunction();
        if(doneCallback){
        doneCallback();
        }
    }

    return(
        <div>
            <p>
            {counter}
            </p>
            <ComponentB updateCount={ (doneCallback) => {updateCount(doneCallback)}}/>
        </div>
    );
}
```

Here to just highlight the function flowing from parent to child
```
function ComponentB(){
    return(
    <div>
      <p>I'm just here for berevity</p>
      <IncrementCount updateCount={updateCount}/>
    </div>
  );
}
```

Component C defines the callback function to be called and passes that to the Function to be called

```
function ComponentC(){
    const [updating, setUpdating] = useState(false);

    function doneCallback(){
    console.log(`Execution finished ${new Date().getMilliseconds()}`)
        setUpdating(false);
    }

    return(
        <button disabled={updating} onClick={ function () { setUpdating(true); return updateCount(doneCallback) }}>Click me!</button>
    );
}
```