output "redshift_alarm_id" {
    value = aws_cloudwatch_metric_alarm.elasticsearch_disk_space_alarm.id
}

output "elasticsearch_alarm_id" {
    value = aws_cloudwatch_metric_alarm.redshift_disk_space_alarm.id
}
