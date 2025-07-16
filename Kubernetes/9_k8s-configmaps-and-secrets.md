# 🔐 Kubernetes ConfigMaps and Secrets

In Kubernetes, **ConfigMaps** and **Secrets** are used to inject configuration and sensitive data into your applications **without hardcoding values in container images** or source code.

---

## 🧾 ConfigMaps

### ✅ What is a ConfigMap?

A ConfigMap is a **key-value store** for non-sensitive configuration data.

Use it for:
- App settings
- Environment variables
- File-based configs

### 🔧 Example: Creating a ConfigMap

```bash
kubectl create configmap app-config --from-literal=ENV=production
```

Or from a file:

```bash
kubectl create configmap app-config --from-file=config.json
```

### 🧪 YAML Example

```yaml
apiVersion: v1
kind: ConfigMap
metadata:
  name: app-config
data:
  ENV: "production"
  APP_NAME: "my-app"
```

### 📥 Mount into a Pod

```yaml
containers:
  - name: myapp
    image: myapp:latest
    envFrom:
      - configMapRef:
          name: app-config
```

---

## 🔑 Secrets

### ✅ What is a Secret?

A Secret is similar to a ConfigMap, but designed for **sensitive data** such as:
- Passwords
- Tokens
- TLS certificates
- API keys

> 📌 Secret values are **Base64 encoded**, not encrypted by default.

### 🔧 Example: Creating a Secret

```bash
kubectl create secret generic db-secret --from-literal=DB_USER=admin --from-literal=DB_PASS=s3cr3t
```

### 🧪 YAML Example

```yaml
apiVersion: v1
kind: Secret
metadata:
  name: db-secret
type: Opaque
data:
  DB_USER: YWRtaW4=    # "admin" in base64
  DB_PASS: czNjcjN0    # "s3cr3t" in base64
```

### 📥 Use in a Pod

```yaml
containers:
  - name: myapp
    image: myapp:latest
    envFrom:
      - secretRef:
          name: db-secret
```

---

## 🧠 Best Practices

| Area               | Recommendation                                                     |
|--------------------|---------------------------------------------------------------------|
| Secrets Handling   | Use tools like SealedSecrets, Vault, or External Secrets Operator   |
| Base64 Awareness   | Remember base64 ≠ encryption                                        |
| RBAC               | Restrict access to Secrets via Kubernetes RBAC                     |
| Separate Concerns  | Use ConfigMaps for config, Secrets for sensitive values             |
| Versioning         | Manage ConfigMap/Secret changes through Git or Helm values          |

---

> ✅ **Tip:** Use `kubectl describe` to inspect ConfigMaps and `kubectl get secret -o yaml` to debug secrets.

