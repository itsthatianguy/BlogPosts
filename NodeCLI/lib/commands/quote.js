'use strict';

const program = require('commander');

const quoter = require('../actions/quoter.js');

program.command('harry-potter')
        .description('Get a Harry Potter quote!')
        .action(() => {
            quoter.harryPotter();
        });

program.command('car-insurance')
        .description('Get a very reasonable car insurance quote! (£10k minimum per annum)')
        .action(() => {
            quoter.carInsurance();
        });

program.parse(process.argv);
