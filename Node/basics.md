# Nodejs

- Environment for running JavaScript code outside of a browser
- Built on Chrome's V8 JavaScript engine
- Big ecosystem of libraries and tools
- Big community
- Full-stack

## Browser vs Node differences

| Browser          | Node        |
| ---------------- | ----------- |
| DOM              | No DOM      |
| Window           | No Window   |
| Interactive Apps | Server Side |
| No Filesystem    | Filesystem  |
| Fragmentation    | Versions    |
| ES6 Modules      | CommonJs    |

## Useful Globals
__dirname - Path to current directory
__filename - Path to current file
require - Function to import modules
module - Info about current module (file)
process - Info about env where the program is being executed

## Modules
- Every file in Node is a module by default
- Encapsulated code (only share minimum)
- export to expose code from a module
- require to import code from a module
- if you use `require` and the module invokes a function, you will get the result of the function in the calling module.

## Built-in Modules
- OS
- PATH
- FS
- HTTP

## NPM
npm i <package> - Install package locally
npm i -g <package> - Install package globally
package.json - manifest file (metadata about project)
npm init - create package.json
npm init -y - create package.json with defaults

## Event Loop
The event loop is what allows Node.js to perform non-blocking I/O operations — despite the fact that JavaScript is single-threaded — by offloading operations to the system kernel whenever possible. 

REPL - Read Eval Print Loop