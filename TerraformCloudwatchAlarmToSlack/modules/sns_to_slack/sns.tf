resource "aws_sns_topic" "sns_notify_slack_topic" {
  name = "${var.application}-slack-notifications-${var.environment}"
}

resource "aws_sns_topic_subscription" "sns_notify_slack_subscription" {
  topic_arn = aws_sns_topic.sns_notify_slack_topic.arn
  protocol  = "lambda"
  endpoint  = aws_lambda_function.sns_notify_slack_lambda.arn
}
