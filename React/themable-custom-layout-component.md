# Themeable Custom Layout Component

Create a custom context that allows the getting and setting of the theme. Keep
this context in a sperate file i.e 'Seperation of Concerns'.

```jsx
export const ThemeContext = createContext();

function ThemeProvider({ children, startingTheme }) {
  const [theme, setTheme] = useState(startingTheme);

  return (
    <ThemeContext.Provider value={{ setTheme, theme }}>
      {children}
    </ThemeContext.Provider>
  );
}
```

This component renders the base for the layout with the theme. But does not use the wrapping provider. This is because it would try to access the context before it is instantiaited. Therefore, we set the layout without the provider in a seperate component.

```jsx
function LayoutNoThemeProvider({ children }) {
  const { theme } = useContext(ThemeContext);

  return (
    <div
      className={
        theme === "light" ? "container-fluid light" : "container-fluid dark"
      }
    >
      {children}
    </div>
  );
}
```

This wraps the no theme provider layout as this component will instantiate the context before rendering its children. Therefore, avoiding a no context defined exception

```jsx
function Layout({ startingTheme, children }) {
  return (
    <ThemeProvider startingTheme={startingTheme}>
      <LayoutNoThemeProvider>{children}</LayoutNoThemeProvider>
    </ThemeProvider>
  );
}
```
