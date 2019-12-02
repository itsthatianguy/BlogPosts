resource "aws_redshift_cluster" "rs_cluster" {
  cluster_identifier = "${var.application}-${var.environment}-redshift-cluster"
  database_name      = "${var.application}_${var.environment}_db"
  master_username    = "rufio"
  master_password    = "superComplexPassw0rd"
  node_type          = "dc1.large"
  cluster_type       = "single-node"
}
