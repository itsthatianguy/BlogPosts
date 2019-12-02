resource "aws_cloudwatch_metric_alarm" "elasticsearch_disk_space_alarm" {
  alarm_name          = "${var.application}-elasticsearch-${var.environment}-disk-alarm"
  alarm_description   = "Remaining ElasticSearch disk space below threshold"
  comparison_operator = "LessThanOrEqualToThreshold"
  evaluation_periods  = "1"
  period              = 60
  threshold           = var.elasticsearch_volume_size * 250 # 25% of the space in Mb
  namespace           = "AWS/ES"
  metric_name         = "FreeStorageSpace"
  statistic           = "Minimum"

  dimensions = {
    DomainName  = var.elasticsearch_domain_name
    ClientId    = var.account_id
  }

  alarm_actions = [

  ]
  ok_actions = [

  ]
}

resource "aws_cloudwatch_metric_alarm" "redshift_disk_space_alarm" {
  alarm_name          = "${var.application}-redshift-${var.environment}-disk-alarm"
  alarm_description   = "Remaining Redshift disk space below threshold"
  comparison_operator = "GreaterThanOrEqualToThreshold"
  evaluation_periods  = "1"
  period              = 60
  threshold           = 75 # Redshift metric is in percentage already
  namespace           = "AWS/Redshift"
  metric_name         = "PercentageDiskSpaceUsed"
  statistic           = "Maximum"

  dimensions = {
    ClusterIdentifier = var.redshift_cluster_id
  }

  alarm_actions = [

  ]
  ok_actions = [

  ]
}
