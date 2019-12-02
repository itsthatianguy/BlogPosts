data "null_data_source" "lambda_file" {
  inputs = {
    filename = "${path.module}/lambda.py"
  }
}

data "null_data_source" "lambda_archive" {
  inputs = {
    filename = "${path.module}/lambda.zip"
  }
}

data "archive_file" "sns_notify_slack_code" {
  type        = "zip"
  source_file = data.null_data_source.lambda_file.outputs.filename
  output_path = data.null_data_source.lambda_archive.outputs.filename
}

resource "aws_lambda_function" "sns_notify_slack_lambda" {
  filename         = data.archive_file.sns_notify_slack_code.output_path
  function_name    = "${var.application}-notify-slack-${var.environment}"
  role             = aws_iam_role.sns_notify_slack_lambda_role.arn
  handler          = "lambda.lambda_handler"
  source_code_hash = data.archive_file.sns_notify_slack_code.output_base64sha256
  runtime          = "python3.6"
  timeout          = 30

  environment {
    variables = {
      SLACK_WEBHOOK     = var.slack_webhook
      SLACK_EMOJI       = var.slack_emoji
    }
  }
}

resource "aws_lambda_permission" "sns_notify_slack_permission" {
  statement_id  = "AllowExecutionFromSNS"
  action        = "lambda:InvokeFunction"
  function_name = aws_lambda_function.sns_notify_slack_lambda.function_name
  principal     = "sns.amazonaws.com"
  source_arn    = aws_sns_topic.sns_notify_slack_topic.arn
}
