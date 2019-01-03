import boto3
import os

def hello(event, context):
    AWS_ACCESS_KEY_ID = os.getenv('AWS_ACCESS_KEY_ID')
    AWS_SECRET_ACCESS_KEY = os.getenv('AWS_SECRET_ACCESS_KEY')
    # AWS_ACCESS_KEY_ID = 'something'
    # AWS_SECRET_ACCESS_KEY = 'something'
    ENDPOINT_URL = os.getenv('S3_ENDPOINT_URL')
    # ENDPOINT_URL = 'http://localstack:4572'
    # print(ENDPOINT_URL)

    my_bucket_name="rufios-bucket"
    my_file_name="plan_for_world_domination.txt"

    s3_client = boto3.client('s3', 
                        endpoint_url=ENDPOINT_URL,
                        aws_access_key_id=AWS_ACCESS_KEY_ID,
                        aws_secret_access_key=AWS_SECRET_ACCESS_KEY)

    create_bucket(s3_client, my_bucket_name)
    create_file(s3_client, my_bucket_name, my_file_name)

    response = {
        "statusCode": 200,
        "body": get_file_body(s3_client, my_bucket_name, my_file_name)
    }
    return response

def create_bucket(s3_client, bucket_name):
    all_buckets = s3_client.list_buckets()
    create_bucket = True
    for bucket in all_buckets['Buckets']:
        if bucket['Name'] == bucket_name:
            create_bucket = False
            break

    if create_bucket:
        print("Bucket doesn't exist - creating bucket")
        bucket = s3_client.create_bucket(Bucket=bucket_name)

def create_file(s3_client, bucket_name, file_name):
    all_files = s3_client.list_objects(
        Bucket=bucket_name
    )

    create_file = True
    if 'Contents' in all_files:
        for item in all_files['Contents']:
            if item['Key'] == file_name:
                create_file = False
                break

    if create_file:
        print("File doesn't exist - creating file")
        response = s3_client.put_object(
            Bucket=bucket_name,
            Body='just keep blogging and hope for the best!',
            Key=file_name
        )

def get_file_body(s3_client, bucket_name, file_name):
    retrieved = s3_client.get_object(
        Bucket=bucket_name,
        Key=file_name
    )
    file_body = retrieved['Body'].read().decode('utf-8')
    print(file_body)
    return file_body