# Terraform

Infrastructure as Code (IaC).

- Manage infrastructure with configuration files
- Allows you to build, change, and manage your infrastructure in a safe, consistent, and repeatable way by defining resource configurations that you can version, reuse, and share.
- Define resources and infrastructure in human-readable, declarative (define the desired end state) configuration files, and manages your infrastructure's lifecycle.

## Advantages

- Multiple cloud platform support.
- Human readable configuration language.
- Terraform's state allows you to track resource changes throughout your deployments.
- You can commit your configurations to version control.

## Standard Flow

- **Scope** - Identify the infrastructure for your project.
- **Author** - Write the configuration for your infrastructure.
- **Initialize** - Install the plugins Terraform needs to manage the infrastructure.
- **Plan** - Preview the changes Terraform will make to match your configuration.
- **Apply** - Make the planned changes.

## Track your infrastructure

Terraform keeps track of your real infrastructure in a state file, which acts as a source of truth for your environment. Terraform uses the state file to determine the changes to make to your infrastructure so that it will match your configuration.