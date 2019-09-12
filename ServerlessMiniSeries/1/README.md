# PART ONE

This folder contains the code for the first post in my Local Serverless Development mini-series.

The code consists of three Lambdas: Java, Python and NodeJS

## Requirements

This example requires use of the [Serverless Framework CLI](https://serverless.com/) and [NodeJS](https://nodejs.org/en/)

## Getting Started

Install NodeJS using the above link  
Then install the Serverless Framework CLI by running the command:
```
npm install -g serverless
```
To check the installation, run the command:
```
serverless --version
```

To invoke, navigate to the root directory of one of the functions and run the command:
```
serverless invoke local --path event.json --function PythonFunction
```
Replacing `PythonFunction` with the name of the chosen function.  
NOTE: The Java code will need packaging first