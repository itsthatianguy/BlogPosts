import json
from botocore.vendored import requests
import os

def lambda_handler(event, context):
    webhook_url = os.environ['SLACK_WEBHOOK']
    emoji = os.environ['SLACK_EMOJI']

    raw_message = json.loads(event['Records'][0]['Sns']['Message'])

    slack_data = {
        'text': event['Records'][0]['Sns']['Subject'],
        'icon_emoji': emoji,
        'attachments': [
            {
                'text': raw_message['AlarmDescription'],
                'title': event['Records'][0]['Sns']['Subject'],
                'color': '#ff9a17'
            }
        ]
    }

    response = requests.post(
        webhook_url, data=json.dumps(slack_data),
        headers={'Content-Type': 'application/json'}
    )
    if response.status_code != 200:
        raise ValueError(f'Request to slack returned an error {response.status_code}, the response is:\n{response.text}')
