# Interactive NodeJS CLI Tool with Inquirer
This is an example of a CLI tool written with Node JS, [Commander](https://www.npmjs.com/package/commander) and [Inquirer](https://github.com/SBoudrias/Inquirer.js)
The blog post this code accompanies can be found here: [https://iamrufio.com/blog/2019/09/node-cli-inquirer/](https://iamrufio.com/blog/2019/09/node-cli-inquirer/)

### Basics
The `index.js` file lays out the root command for the application.  
`lib/actions` contains the only action, separated out into the file `quizzer.js`.

### Prerequisites
This project requires you to have [NodeJS](https://nodejs.org/en/) installed.

### Setup
First run `npm install` to install dependencies.  
Then run the command `node ./index.js quiz` and answer the questions, and see the output.
