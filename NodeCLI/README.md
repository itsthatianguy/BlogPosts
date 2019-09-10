# NodeJS CLI Tool with Commander
This is an example of a CLI tool written with Node JS and [Commander](https://www.npmjs.com/package/commander)
The blog post this code accompanies can be found here: [https://iamrufio.com/blog/2019/09/node-cli-commander/]()

### Basics
The `index.js` file lays out the root commands for the application.  
`lib/commands` is used as an example of separating out sub-commands, and likewise `lib/actions` is used if you want to separate out the actions from the commands themselves.

### Prerequisites
This project requires you to have [NodeJS](https://nodejs.org/en/) installed.

### Setup
First run `npm install` to install dependencies.  
Then you can run commands using `node ./index.js quote harry-potter` for example.  
Run `node ./index.js --help` to get a list of commands.  
Alternatively, you can install the package globally using `npm install -g ./` and then you'll be able to run `node-cli quote harry-potter` instead.
