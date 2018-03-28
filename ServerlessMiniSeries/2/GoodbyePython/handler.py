import json
import os

def goodbye(event, context):
    running_env = os.getenv('RUNNING_ENVIRONMENT')
    response = {
        "statusCode": 200,
        "body": "This is the Goodbye Python Lambda. The running environment is {0}".format(running_env)
    }
    return response
