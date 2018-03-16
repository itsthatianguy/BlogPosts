import json
import os

def hello(event, context):
    running_env = os.getenv('RUNNING_ENVIRONMENT')
    name = event["name"]
    print('The running environment is {0}'.format(running_env))
    print('Hello {0}'.format(name))
