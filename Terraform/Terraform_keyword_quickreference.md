# Terraform quick reference

- **terraform** - conatains the terraform setings including required providers
  - **required_providers** - specifies the required providers for the configuration
    - **soucrce** - optional hostname, namespace and provider type. providers are installaed from the terraform registry.
    - **version** - version constraints for the provider
- **provider** - configure the specified provider
- **resource** - define compoenents of the infrastructure

# Command line
- **terraform init** - initialize a working directory containing Terraform configuration files. This is the first command that should be run after writing a new Terraform configuration or cloning an existing one from version control.
- **terraform fmt** - rewrite Terraform configuration files to a canonical format and style.
- **terraform validate** - validates the configuration files in a directory, referring only to the configuration and not accessing any remote services such as remote state, provider APIs, etc.
- **terraform apply** - applies the changes required to reach the desired state of the configuration, as described by the configuration files in the directory.
- **teraform destory** - destory all infrastructure managed by terraform