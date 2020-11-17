# FastAPI Docker Container
This is an example of how to run a [FastAPI](https://fastapi.tiangolo.com/) project inside a Docker container.  
The blog post this code accompanies can be found here: [https://ianrufus.com/blog/2020/11/fastapi-docker](https://ianrufus.com/blog/2020/11/fastapi-docker)

### Building the Image
Navigate to the root of this sub-project.  
Run the command `docker build -t fastapi-demo .`

### Running the Image
Stay in the root of this sub-project.  
Run the command `docker run -p 8000:8000 -v "${PWD}/src:/app/src" fastapi-demo`  
This will run the container on port 8000, and will mount the source code as a volume on the container, allowing any changes made locally to be reflected on the container without having to rebuild.

### Known Issues
There are issues stopping the container with `ctrl + c` - instead you may find you need to use `docker kill` to stop the container.  
This is down to an issue with Uvicorn. The issue was originally addressed in [this PR](https://github.com/encode/uvicorn/pull/620) but introduced a new issue and had to be reverted in [this PR](https://github.com/encode/uvicorn/pull/756).  
At the time of writing, the only way to avoid this was to remove the `--reload` argument in the command and not use the hot reloading.
