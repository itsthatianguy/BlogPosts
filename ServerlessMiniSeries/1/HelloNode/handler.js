'use strict';

module.exports.hello = (event, context, callback) => {
  var env = process.env.RUNNING_ENVIRONMENT
  console.log('The running environment is ' + env);
  var name = event["name"];
  console.log('Hello ' + name);
};
