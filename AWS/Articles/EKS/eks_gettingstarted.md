# Amazon EKS (Elastic Kubernetes Service) - Getting Started

These notes are take from the [Getting Started with EKS]("https://docs.aws.amazon.com/eks/latest/userguide/getting-started-console.html") guide.

## Step 1: Create an Amazon EKS cluster
1. Create a VPC with public and private subnets
2. Create cluster IAM role and attach the required policies `arn:aws:iam::aws:policy/AmazonEKSClusterPolicy`
3. Create EKS cluster in console

## Step 2: Configure your computer to communicate with your cluster
1. Create kubeconfig `aws eks update-kubeconfig --region region-code --name my-cluster`
2. Test `kubectl get svc`

## Step 3
1. Create Nodes (Fargate Example)
   1. Create IAM role and attach `Amazon EKS IAM managed policy`
   2. Create pod execution role
   3. Attach Amazon EKS managed IAM policy to role
2. Create Fargate profile
3. Create 2nd fargate profile for `CoreDNS`.
   1. Should create 2 nodes in the cluster
   2. Node groups not applicable to fargate pods