# Razor View Engine Email Templates Example
This is an example of how to use the RazorViewEngine to render .cshtml files in order to get the string output.
The blog post this code accompanies can be found here: <TBD>

### Basics
This solution comprises of two projects:
- Web API
- Console Application

The API handles the rendering of an email view file, the console application is simply a helpful way of quickly testing the API.

### Prerequisites
This project is built for .NET Core 2.0
If needed, you can find this here: https://www.microsoft.com/net/core

### Setup
To run the code simply build the project with dotnet and then run the projects.
The API is configured to run on port 5020 - change this in the Program class if desired.