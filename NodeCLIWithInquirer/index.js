'use strict';

const program = require('commander');
const inquirer = require('inquirer');

const quizzer = require('./lib/actions/quizzer.js');

program.name('node-cli').usage('command [options]');

program.command('quiz')
        .action(async () => {
            const questions = quizzer.getQuestions();
            const answers = await inquirer.prompt(questions);
            quizzer.processAnswers(answers);
        });

program.parse(process.argv);
