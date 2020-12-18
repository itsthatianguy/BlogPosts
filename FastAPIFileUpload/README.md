# FastAPI File Uploads
This is an example of how to handle file uploads in a [FastAPI](https://fastapi.tiangolo.com/) project.  
The blog post this code accompanies can be found here: [https://ianrufus.com/blog/2020/12/fastapi-file-upload](https://ianrufus.com/blog/2020/12/fastapi-file-upload)

## Getting Started
In this directory, create your virtual environment for Python 3:  
`python3 -m venv virtualenv`

Then activate the environment:  
`source virtualenv/bin/activate`

Then you need to install the requirements for the project:  
`pip install -r requirements.txt`

Now you can run the API:  
`python src/main.py`

You can then send a valid request however you want.  
There's an image included in this folder that can be used to test the endpoint.  
To use this with cURL you could do:  
`curl --request POST -F "file=@./python.png" localhost:8000`
