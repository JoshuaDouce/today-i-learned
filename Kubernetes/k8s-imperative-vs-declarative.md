# 📦 Kubernetes Imperative Commands: Quick Guide & Caveats

Kubernetes offers two primary ways to interact with your cluster:

1. **Imperative** — You tell Kubernetes *what to do*, *right now*.
2. **Declarative** — You tell Kubernetes *what the desired state is*, and it works to maintain it.

This guide focuses on **imperative commands**, what they do, and **why they are discouraged** for long-term, production-grade workflows.

---

## ⚡ What Are Imperative Commands?

Imperative commands are direct, one-off instructions using the `kubectl` CLI. You execute them manually to create or modify Kubernetes resources.

### 🔧 Common Examples

```bash
# Create a deployment
kubectl create deployment nginx --image=nginx

# Expose a deployment as a service
kubectl expose deployment nginx --port=80 --type=LoadBalancer

# Scale a deployment
kubectl scale deployment nginx --replicas=3

# Delete a resource
kubectl delete pod my-pod

# Edit a running resource
kubectl edit deployment nginx
```

These commands are **quick and effective** for small changes, testing, or learning.

---

## 🚫 Why Not Use Imperative Commands in Production?

While convenient, imperative commands come with significant drawbacks:

### 1. **No Source of Truth**
- Changes live only in the cluster, not in version control.
- If a pod dies and you don’t remember how it was created, it’s gone for good.

### 2. **No Auditability or History**
- You can't track *what was changed*, *when*, or *by whom*.
- Troubleshooting or rollback becomes difficult.

### 3. **No Reproducibility**
- You can't easily replicate environments across dev/stage/prod.
- Manual steps are error-prone and inconsistent.

### 4. **Not GitOps-Friendly**
- Tools like **Flux** or **Argo CD** rely on **declarative manifests** in Git.
- Imperative changes break the Git → Cluster sync model.

---

## ✅ What You Should Use Instead: Declarative Approach

Define your resources in YAML files:

```yaml
# deployment.yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: nginx
spec:
  replicas: 3
  selector:
    matchLabels:
      app: nginx
  template:
    metadata:
      labels:
        app: nginx
    spec:
      containers:
        - name: nginx
          image: nginx
```

Apply them with:

```bash
kubectl apply -f deployment.yaml
```

Track them in Git, review changes via Pull Requests, and let GitOps tools manage syncing.

---

## ✅ When *Are* Imperative Commands Okay?

- Learning and experimentation
- Quick one-off tasks in dev environments
- Generating initial YAML with `--dry-run=client -o yaml`

```bash
kubectl create deployment nginx --image=nginx --dry-run=client -o yaml > nginx-deployment.yaml
```

---

## 📝 Summary

| Aspect            | Imperative | Declarative      |
| ----------------- | ---------- | ---------------- |
| Speed             | ✅ Fast     | 🚫 Slower upfront |
| Repeatable        | 🚫 No       | ✅ Yes            |
| GitOps-Compatible | 🚫 No       | ✅ Yes            |
| Auditable         | 🚫 No       | ✅ Yes            |
| Team-Friendly     | 🚫 No       | ✅ Yes            |

---

> 🧠 **Best Practice:** Use imperative commands to learn or prototype, but always migrate to declarative YAML files under version control for real-world use.
