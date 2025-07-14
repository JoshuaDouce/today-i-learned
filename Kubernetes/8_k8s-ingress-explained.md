# 🌐 Kubernetes Ingress: What It Is and How to Use It

A **Kubernetes Ingress** is an API object that manages **external HTTP(S) access** to services in a cluster.  
It's the preferred way to expose multiple services under the same IP or domain using **path-based** or **host-based** routing.

---

## ❓ Why Use Ingress?

- Expose multiple services over HTTP/HTTPS using **one external IP**
- Centralize **TLS (SSL)** termination
- Apply **routing rules** (e.g., `/api` goes to one service, `/app` to another)
- Integrate with authentication, rate limiting, or custom headers

---

## ⚙️ How Ingress Works

1. You deploy an **Ingress Controller** (e.g., NGINX, Traefik, HAProxy)
2. You define **Ingress rules** that map URLs/paths to Services
3. The controller watches these rules and updates its routing config

---

## 🧪 HTTP Ingress Example

This exposes two services (`web` and `api`) under different paths:

```yaml
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: example-ingress
  annotations:
    nginx.ingress.kubernetes.io/rewrite-target: /
spec:
  rules:
    - host: myapp.local
      http:
        paths:
          - path: /web
            pathType: Prefix
            backend:
              service:
                name: web
                port:
                  number: 80
          - path: /api
            pathType: Prefix
            backend:
              service:
                name: api
                port:
                  number: 80
```

> 🔁 Access with:
> - `http://myapp.local/web`
> - `http://myapp.local/api`

---

## 🔐 HTTPS Ingress Example (TLS)

This enables SSL using a Kubernetes Secret:

```yaml
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: secure-ingress
spec:
  tls:
    - hosts:
        - mysecureapp.com
      secretName: tls-secret  # contains tls.crt and tls.key
  rules:
    - host: mysecureapp.com
      http:
        paths:
          - path: /
            pathType: Prefix
            backend:
              service:
                name: secure-service
                port:
                  number: 443
```

> 🔐 Use cert-manager or manually create TLS secrets with:
> ```bash
> kubectl create secret tls tls-secret --cert=cert.crt --key=key.key
> ```

---

## 🧠 Common Ingress Controllers

| Controller | Description                  |
|------------|------------------------------|
| NGINX      | Most popular, widely used    |
| Traefik    | Lightweight, dynamic config  |
| HAProxy    | High-performance proxy       |
| Istio      | Integrated with service mesh |

---

## 📌 Summary

| Feature           | Service | Ingress |
|------------------|---------|---------|
| L4 (TCP/UDP)     | ✅ Yes  | 🚫 No   |
| L7 (HTTP/HTTPS)  | 🚫 No   | ✅ Yes  |
| Path-based rules | 🚫 No   | ✅ Yes  |
| TLS termination  | 🚫 No   | ✅ Yes  |
| Centralized entry| 🚫 No   | ✅ Yes  |

> ✅ **Best Practice:** Use Ingress for complex HTTP(S) routing and external access.  
> Use `LoadBalancer` only for simple use cases or non-HTTP traffic.
