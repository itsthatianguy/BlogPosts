resource "aws_elasticsearch_domain" "es_domain" {
  domain_name           = "${var.application}-${var.environment}-elasticsearch"
  elasticsearch_version = "1.5"

  cluster_config {
    instance_type = "r4.large.elasticsearch"
  }

  snapshot_options {
    automated_snapshot_start_hour = 23
  }

  tags = {
    Domain = "TestDomain"
  }
}
