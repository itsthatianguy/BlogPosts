# PART THREE

This folder contains the code for the third post in my Local Serverless Development mini-series.

The code consists of two Python Lambdas - HelloPython and GoodbyePython 
These are defined as a single API Gateway in `serverless.yml`

## Requirements

The requirements for this part build on the requirements from the previous two posts, ensure those are installed before continuing.  
You'll also need to install [LocalStack](https://github.com/localstack/localstack).

## Getting Started

Install the Serverless SAM plugin, for exporting the SAM template from the Serverless template:
```
npm install serverless-sam
```

Export the SAM template from the Serverless template:
```
serverless sam export -o template.yml
```

Install AWS SAM Local:
```
pip install --user aws-sam-cli
```

Install LocalStack:
```
pip install localstack
```

Start LocalStack on Windows using Docker:
```
docker run -p 8080:8080 -p 4567-4582:4567-4582 -e SERVICES=s3,dynamodb localstack/localstack
```

Start LocalStack on Mac/Linux:
```
SERVICES=s3,dynamodb localstack start
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
will invoke the corresponding functions.

To view the LocalStack dashboard, navigate to `localhost:8080`