# Debugging Microservices with Docker Compose and HAProxy Example
This is an example of how I've been using Docker Compose and HAProxy to debug microservices, only having to run the components I'm interested in outside of the Docker Compose.
The blog post this code accompanies can be found here: https://iamrufio.com/2017/11/10/debugging-microservices-with-docker-compose-and-haproxy/

### Basics
This solution comprises of three projects:
- Web API
- Web Project
- DTO Library

The API very basically returns a DTO containing the word 'Hello!'.
The Website simply calls the API, with a base address passed in as an environment variable, and displays the result.

The more important components for this example are the `docker-compose.yml` file and the `haproxy.cfg` file.
The compose file handles the containers to start, and their environment variables.
The config file sets out our reverse proxy rules for HAProxy.

### Prerequisites
The code for this project was written in .NET Core 2.0.
If needed, you can find this here: https://www.microsoft.com/net/core

You'll also require Docker, which can be found here: https://www.docker.com/get-docker

### Setup
To run the compose file, the projects first need to be built and published.
To publish the projects, navigate to their folder, and run `dotnet publish -c Release -o publish`
Then navigate back to the folder containing the compose file and build that by running `docker-compose build`
You can now spin up the compose file using `docker-compose up`

To see the fallback working, you can debug the Web app on port 5020, or the API on port 8020.