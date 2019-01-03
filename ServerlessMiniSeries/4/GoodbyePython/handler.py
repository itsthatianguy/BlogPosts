import json
import os
import boto3

def goodbye(event, context):
    AWS_ACCESS_KEY_ID = os.getenv('AWS_ACCESS_KEY_ID')
    AWS_SECRET_ACCESS_KEY = os.getenv('AWS_SECRET_ACCESS_KEY')
    ENDPOINT_URL = os.getenv('DYNAMO_ENDPOINT_URL')
    
    client = boto3.client('dynamodb', 
                        endpoint_url=ENDPOINT_URL,
                        aws_access_key_id=AWS_ACCESS_KEY_ID,
                        aws_secret_access_key=AWS_SECRET_ACCESS_KEY)

    my_table_name = "rufios-table"
    my_attribute_name = "rufios-key"
    my_key_value = "world domination plan"

    create_table(client, my_table_name, my_attribute_name)
    create_item(client, my_table_name, my_attribute_name, my_key_value)
    
    response = {
        "statusCode": 200,
        "body": "Database is up to date!"
    }
    return response

def does_table_need_creating(dynamo_client, table_name):
    all_tables = dynamo_client.list_tables()

    create_table = True
    for table in all_tables['TableNames']:
        if table == table_name:
            create_table = False
            break
    return create_table

def create_table(dynamo_client, table_name, attribute_name):
    if does_table_need_creating(dynamo_client, table_name):
        print('Table not found - creating table')
        dynamo_client.create_table(
            AttributeDefinitions=[
                {
                    'AttributeName': attribute_name,
                    'AttributeType': 'S'
                },
            ],
            TableName=table_name,
            KeySchema=[
                {
                    'AttributeName': attribute_name,
                    'KeyType': 'HASH'
                },
            ],
            ProvisionedThroughput={
                'ReadCapacityUnits': 123,
                'WriteCapacityUnits': 123
            }
        )

def does_item_need_creating(dynamo_client, table_name, attribute_name, key_value):
    get_item_response = dynamo_client.get_item(
        TableName=table_name,
        Key={
            attribute_name: {
                'S': key_value
            }
        }
    )
    create_item = True
    if 'Item' in get_item_response:
        create_item = False
    return create_item

def create_item(dynamo_client, table_name, attribute_name, key_value):
    if does_item_need_creating(dynamo_client, table_name, attribute_name, key_value):
        print('Item not found - creating item')
        item_response = dynamo_client.put_item(
            TableName=table_name,
            Item={
                attribute_name: {
                    'S': key_value
                }
            }
        )