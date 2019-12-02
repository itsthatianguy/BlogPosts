# CloudWatch Alarms Posting to Slack using Terraform

This is an example of how to create CloudWatch alarms that, when triggered, will send a message to SNS, which invokes a Lambda, which posts the message to a configured Slack webhook.
The blog post this code accompanies can be found here: https://iamrufio.com/2019/12/02/terraform-cloudwatch-to-slack/

## Requirements

This example requires you to have an AWS account created with the credentials configured as environment variables, and to have [Terraform](https://www.terraform.io/) installed.

## Getting Started

This example comes with variables pre-configured to make trying it out easy - though some will need changing in order for a fully successful deployment.  
The first thing to do is to initialize Terraform:  
`terraform init`  
Once successfully initialized, you can then run a plan to ensure it will create the correct resources:  
`terraform plan`

You can check the terminal output to see the results.  
If you want to deploy, change the variables according to your own configuration, then simply run:  
`terraform apply`  
And follow the prompts.  
