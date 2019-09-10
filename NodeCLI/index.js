'use strict';

const program = require('commander');

const greeter = require('./lib/actions/greeter.js');

program.name('node-cli').usage('command [options]');
program.on('--help', () => {
    console.log('');
    console.log('Blame Rufio for this mess');
});

program.command('say-hello <name>')
        .alias('hi')
        .option('-c, --compliment', 'Need a self esteem boost?', false)
        .action((name, args) => {
            greeter.hello(name, args.compliment);
        });

program.command('quote [command]', 'Get a quote!', {executableFile: 'lib/commands/quote'});

program.parse(process.argv);
