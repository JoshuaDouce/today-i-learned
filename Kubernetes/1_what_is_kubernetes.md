# What is Kubernetes?

Kubernetes is an open source container orchestrator.

# Key Features of Kubernetes and Their Benefits

1. **Container Orchestration**
   - **Why Desirable**: Automates the deployment, scaling, and management of containerized applications, simplifying workflows and resource management.
   - **Why Containerized Applications**:
     - ***Portability***: Containers can run consistently across different environments, from development to production (Run Everywhere).
     - ***Isolation***: Containers encapsulate applications and their dependencies, ensuring they run in isolation without conflicts.
     - ***Lightweight***: Containers share the host OS kernel, making them more resource-efficient compared to traditional virtual machines.
     - ***Scalability***: Containers can be easily scaled up or down based on demand, allowing for efficient resource utilization.
     - ***Simplified CI/CD***: Containers streamline continuous integration and deployment processes, enabling faster development cycles and easier rollbacks. Use tools like Flux/ArgoCD for GitOps workflows.
     - ***Ecosystem Support***: Containers have a rich ecosystem with tools for monitoring, logging, and security, enhancing operational capabilities.
     - ***Security(When managed correctly)***: Containers can be isolated from each other, reducing the attack surface and improving security posture. 

2. **Scalability**
   - **Why Desirable**: Enables automatic scaling of applications up or down based on demand, ensuring efficient resource use and maintaining performance during peak loads.

3. **High Availability**
   - **Why Desirable**: Reduces application downtime by managing failovers and maintaining operational continuity, essential for business-critical applications.

4. **Portability**
   - **Why Desirable**: Supports running applications across various environments (cloud, on-prem, hybrid), helping avoid vendor lock-in and facilitating easy migrations.

5. **Automated Rollouts and Rollbacks**
   - **Why Desirable**: Facilitates updates and changes by automating deployments and safely rolling back to previous versions if necessary, enhancing development agility.

6. **Service Discovery and Load Balancing**
   - **Why Desirable**: Manages network traffic and service discovery automatically, ensuring applications are accessible and perform well under varying loads.

7. **Secret and Configuration Management**
   - **Why Desirable**: Manages and stores sensitive information securely, allowing updates and configurations without hardcoding secrets into images or exposing them.

8. **Storage Orchestration**
   - **Why Desirable**: Automatically attaches storage systems to containers, supporting stateful applications and simplifying data management across diverse storage solutions.

9. **Self-healing**
   - **Why Desirable**: Handles failures automatically and maintains application health by replacing or repairing faulty instances, minimizing downtime and manual intervention.

10. **Declarative Configuration and Automation**
    - **Why Desirable**: Allows precise control over infrastructure with version-controlled configurations that can be automatically applied, easing management of complex deployments and maintaining consistency across environments.

# Introduction

- Kubernetes cluster is a set of nodes grouped together.
- Node (machine or VM) is the smallest unit in Kubernetes. A node can be a physical machine or a virtual machine.
- As long as the cluster has sufficient resources, it can run any containerized application.
- Pods (a container) are the smallest deployable units in Kubernetes. A Pod represents a single instance of a running process in your cluster. 
  - Pods are transient and can be created, destroyed, and replicated dynamically.
  - Pods have a unique IP address within the cluster.
  - Pods can communicate with other pods, regardless of which host they run on.
  - New pods created with new versions of your application can replace older ones.
- A service is a logical set of pods that provide the same functionality.
- Namespaces are a way to divide cluster resources between multiple users.
- Kind is a way to group resources together. For example, a Pod is a kind of resource.
- Deployment is a way to manage the lifecycle of pods and are per service.
- You can create a pod from the command line, this is called a static pod. However, it is recommended to use a deployment to manage pods.
- 'Deployments' are per service and manage the lifecycle of pods.
