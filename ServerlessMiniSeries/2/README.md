# PART TWO

This folder contains the code for the second post in my Local Serverless Development mini-series.

The code consists of two Python Lambdas - HelloPython and GoodbyePython 
These are defined as a single API Gateway in `serverless.yml`

## Requirements

The requirements for this part build on the requirements from the previous post, ensure those are installed before continuing.  
You'll also need to install [Docker](https://docker.com) to run AWS SAM Local

## Getting Started

Install the Serverless SAM plugin, for exporting the SAM template from the Serverless template:
```
npm install serverless-sam
```

Install AWS SAM Local:
```
npm install aws-sam-local --save-dev
```

To start the API, navigate to the root directory of this section and run the command:
```
sam local start-api
```

Hitting the endpoints
```
localhost:3000/hello
localhost:3000/goodbye
```
will invoke the corresponding functions