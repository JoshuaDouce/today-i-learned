# Delay the side effect of an input.

Declare the input & side effect in state
```
const [password, setPassword] = useState('');
const [passwordInvalid, setPasswordInvalid] = useState(!isValid(password) && password !== '');
```

In use effect declare a timeout and the side effect state update. Pass input as parameter to use effect to ensure it only re-renders on updates to that state value.
```
useEffect(() => {
    const evaluateInputTimeout = setTimeout(() => {
      setPasswordInvalid(!isValid(password) && password !== '');
    }, 500);
    return () => clearTimeout(evaluateInputTimeout);
  }, [password);
```

see [reactjs-delay-onchange-while-typing](https://stackoverflow.com/questions/53071774/reactjs-delay-onchange-while-typing) 

further reading -> [lodash debounce](https://lodash.com/docs/#debounce)