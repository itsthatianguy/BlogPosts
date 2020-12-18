import uvicorn
from fastapi import FastAPI, UploadFile, File
import time
import os 


app = FastAPI()

@app.post("/")
async def receive_file(file: UploadFile = File(...)):
    dir_path = os.path.dirname(os.path.realpath(__file__))
    filename = f'{dir_path}/uploads/{time.time()}-{file.filename}'
    f = open(f'{filename}', 'wb')
    content = await file.read()
    f.write(content)

if __name__ == "__main__":
    uvicorn.run("main:app", port=8000, reload=True)
