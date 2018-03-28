import json
import os

def hello(event, context):
    running_env = os.getenv('RUNNING_ENVIRONMENT')
    response = {
        "statusCode": 200,
        "body": "This is the Hello Python Lambda. The running environment is {0}".format(running_env)
    }
    return response
