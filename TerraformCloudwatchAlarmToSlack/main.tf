variable "account_id" {
    default = "some account id"
}

variable "application" {
    default = "blog"
}

variable "environment" {
    default = "dev"
}

variable "slack_emoji" {
    default = ":robot_face:"
}

variable "slack_webhook" {
    default = "some-webhook"
}

variable "elasticsearch_volume_size" {
    default = 10
}

provider "aws" {
    version = "~> 2.0"
    region  = "eu-west-2"
}

module "sns_to_slack" {
    source  = "./modules/sns_to_slack"

    account_id                = var.account_id
    application               = var.application
    environment               = var.environment
    slack_emoji               = var.slack_emoji
    slack_webhook             = var.slack_webhook
    elasticsearch_volume_size = var.elasticsearch_volume_size
    redshift_cluster_id       = aws_redshift_cluster.rs_cluster.id
    elasticsearch_domain_name = aws_elasticsearch_domain.es_domain.domain_name
}
