# 🤝 Kubernetes Sidecar Containers: Concept and Use Cases

In Kubernetes, a **sidecar container** is a secondary container that runs in the **same Pod** as the main application container. Sidecars share the same network namespace and volumes, making them ideal for providing supporting functionality.

---

## 🧱 Basic Sidecar Pod Example

Here's a Pod with:
- A main container (`my-app`)
- A sidecar container (`log-agent`) for shipping logs

```yaml
apiVersion: v1
kind: Pod
metadata:
  name: sidecar-demo
spec:
  containers:
    - name: my-app
      image: my-app-image
      volumeMounts:
        - name: shared-logs
          mountPath: /var/log/myapp

    - name: log-agent
      image: busybox
      command: ["sh", "-c", "tail -n+1 -F /var/log/myapp/app.log"]
      volumeMounts:
        - name: shared-logs
          mountPath: /var/log/myapp

  volumes:
    - name: shared-logs
      emptyDir: {}
```

---

## 🧠 Why Use Sidecars?

Sidecars are ideal when you want containers to **collaborate tightly** within the same Pod. Below are common scenarios:

### 🔸 1. **Log Shipping**
Use a sidecar (e.g., Fluent Bit) to collect logs from app containers and forward them to a centralized logging system.

### 🔸 2. **Proxy / Service Mesh**
Envoy sidecars (used in Istio, Linkerd) intercept network traffic for observability, security, and retries.

### 🔸 3. **Data Sync or Backups**
Run a sidecar that periodically syncs data from a shared volume to remote storage (e.g., S3 or GCS).

### 🔸 4. **Certificate Renewal**
Run a sidecar that renews TLS certificates (e.g., cert-manager, kube-lego) and writes them to a shared volume.

### 🔸 5. **Init or Configuration Support**
Although init containers are preferred for one-time setup, sidecars can support **continuous config updates** or **pulling secrets** from external systems.

---

## 📌 Important Considerations

- All containers in a Pod share:
  - **Network namespace** (localhost access)
  - **Volumes** (via mounts)
- If **any container fails**, the whole Pod may be restarted depending on restart policy.
- Sidecars should be built to gracefully handle restarts and shared lifecycle with the main app.

---

> ✅ **Best Practice**: Use sidecars for tightly coupled, helper processes. If decoupling is possible, consider deploying as separate services.

