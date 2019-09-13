'use strict';

require('colors');

const quizzer = {
    getQuestions: () => {
        return [
            { type: 'list',     name: 'listExample',        message: 'A list example to start with:', default: 2, choices: ['Item 1', 'Item 2', 'Item 3']},
            { type: 'checkbox', name: 'checkboxExample',    message: 'And now for a checkbox:', default: ['Checky', 'Checky Check Check'],      choices: ['Checky', 'Checky Check', 'Checky Check Check']},
            { type: 'confirm',  name: 'confirmExample',     message: 'Is this annoying you yet:',     default: true},
            { type: 'expand',   name: 'expandExample',      message: 'And now expand...',             choices: [{key: 'x', name: 'Expand'}, { key: 'a', name: `Yes! It's an extender!`}]},
            { type: 'input',    name: 'inputExample',       message: 'This is tedious. Tell me about it:', default: 'This is a weird form of torture.'},
            { type: 'number',   name: 'numberExample',      message: 'How high can you count:',
                validate: function(value) {
                    const valid = !isNaN(parseInt(value));
                    return valid || "Please enter a number";
                }
            },
            { type: 'password', name: 'passwordExample',    message: `Password please. Shh I won't tell anyone:`},
        ];
    },
    processAnswers: (answers) => {
        console.log('And now for the thrilling output:'.green);
        console.log(`You chose list item ${answers.listExample}`.blue);
        console.log(`And you checked items: ${answers.checkboxExample}`.blue);
        const bovvered = answers.confirmExample ? `yes, this is ridiculous` : `no, you're not annoyed`;
        console.log(`And you indicated that ${bovvered}`.blue);
        console.log(`You chose ${answers.expandExample} for the expandable question`.blue);
        console.log(`How tedious was all this? You said ${answers.inputExample}`.blue);
        console.log(`But at least you can count to ${answers.numberExample}`.blue);
        console.log(`Don't worry though. Your password is super secure. I won't tell anyone that it's '${answers.passwordExample}'`.blue);
    }
};

module.exports = quizzer;
