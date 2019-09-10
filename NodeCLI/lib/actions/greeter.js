'use strict';

const greeter = {
    hello: (name, compliment) => {
        let output = `Hello ${name}!`;
        if (compliment) {
            output = `${output} You look beautiful today!`;
        }
        console.log(output);
    }
};

module.exports = greeter;
