# Local Serverless Development

This is the repo containing sample code for my Local Serverless Development mini-series.  
This was first published on my [personal blog](https://ianrufus.com)

Each of the individual blog posts will contain all code in a separate directory inside this repo.  
As I publish new posts, the code will be added in a new numerically named folder.

## Getting Started

Each of the individual directories contains a README with information on dependencies and running the code for that specific post.

## Part 1
[The blog post for part 1 can be found here](https://ianrufus.com/2018/03/19/local-serverless-development-part-1-invoking-lambdas-locally/)

Part 1 covers invoking functions locally.  
[The code can be found here](https://github.com/ianrufus/BlogPosts/tree/master/ServerlessMiniSeries/1)

The code consists of three separate Serverless functions - one each for Python, NodeJS and Java.  
The functions simply print out a name from the supplied event data, and a variable from a provided environment variables file.

## Part 2
[The blog post for part 2 can be found here](https://ianrufus.com/blog/2018/03/local-serverless-development-part-2-running-api-gateway-locally/)

Part 2 covers running lambdas locally through API Gateway.  
[The code can be found here](https://github.com/ianrufus/BlogPosts/tree/master/ServerlessMiniSeries/2)

The code consists of two separate Serverless functions written in Python.  
The functions print out a message and a variable from a provided environment variables file.

## Part 3
[The blog post for part 3 can be found here](https://ianrufus.com/blog/2018/07/local-serverless-development-part-3-localstack/)

Part 3 covers using LocalStack to mimic AWS components without deploying anything.  
[The code can be found here](https://github.com/ianrufus/BlogPosts/tree/master/ServerlessMiniSeries/3)  

The code consists of two separate Serverless functions written in Python as in Part 2, but modified to use LocalStack.  

## Part 4
[The blog post for part 4 can be found here](https://ianrufus.com/blog/2019/01/local-serverless-development-part-4-streamlining-development/)

Part 4 covers streamlining the local development environment using Docker Compose.  
[The code can be found here](https://github.com/ianrufus/BlogPosts/tree/master/ServerlessMiniSeries/4)  

The code consists of two separate Serverless functions written in Python as in Parts 2 and 3. It also includes a Docker Compose file and a Makefile to make spinning up the services easier.