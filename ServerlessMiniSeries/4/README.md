# PART FOUR

This folder contains the code for the fourth and final post in my Local Serverless Development mini-series.  

The code consists of two Python Lambdas - HelloPython and GoodbyePython  
These are defined as a single API Gateway in `serverless.yml`  
A `docker-compose.yml` file spins up the services, with a Makefile to make the process easier.

## Requirements

The requirements for this part build on the requirements from the previous two posts, ensure those are installed before continuing.  
Ensure that you have Docker Compose installed, at least version 1.18.0

## Getting Started

This example is supposed to be as easy to use as possible.  
To install the Serverless SAM plugin for exporting the SAME template, and to pull down the LocalStack and AWS SAM Local Docker images, run:
```
make init
```

Once initialised, you can export the template and spin up the service with one command:
```
make run
```

Hitting the endpoints
```
localhost:3000/hello
localhost:3000/goodbye
```
will invoke the corresponding functions.

To view the LocalStack dashboard, navigate to `localhost:8080`