# 🔍 Kubernetes Probes: Liveness, Readiness, and Startup

Kubernetes provides **three types of probes** to monitor and manage the health and availability of containers within Pods:

1. **Liveness Probe**
2. **Readiness Probe**
3. **Startup Probe**

Each probe has specific use cases and behaviors that help Kubernetes decide whether to **restart a container**, **send traffic to it**, or **give it time to initialize**.

---

## 🫀 1. Liveness Probe

### Purpose:
Determines if the **container is still alive**.  
If the liveness probe fails, Kubernetes will **restart the container**.

### Common Use Case:
Detecting deadlocks or application crashes that don’t cause the container to exit.

### Example:

```yaml
livenessProbe:
  httpGet:
    path: /healthz
    port: 8080
  initialDelaySeconds: 5
  periodSeconds: 10
```

### Key Properties:
| Property             | Description                                                       |
|----------------------|-------------------------------------------------------------------|
| `httpGet` / `tcpSocket` / `exec` | Type of probe (HTTP, TCP, or command)                          |
| `initialDelaySeconds` | Time before the first probe after container start                |
| `periodSeconds`      | Frequency of probing                                              |
| `failureThreshold`   | Number of failures before restarting                              |
| `timeoutSeconds`     | How long to wait for a response                                   |

---

## 🌐 2. Readiness Probe

### Purpose:
Checks if the container is **ready to serve traffic**.  
If the readiness probe fails, Kubernetes will **remove the pod from Service endpoints** — it won't receive requests.

### Common Use Case:
Waiting for an app to finish booting or warm-up tasks before receiving traffic.

### Example:

```yaml
readinessProbe:
  httpGet:
    path: /ready
    port: 8080
  initialDelaySeconds: 5
  periodSeconds: 10
```

### Key Properties:
Same as liveness probe:
- `httpGet` / `tcpSocket` / `exec`
- `initialDelaySeconds`
- `periodSeconds`
- `failureThreshold`
- `timeoutSeconds`

---

## 🚀 3. Startup Probe

### Purpose:
Designed for **slow-starting containers**.  
Disables other probes until the startup probe succeeds. This prevents liveness/readiness probes from killing the app during its startup phase.

### Common Use Case:
Legacy apps, JVM-based services, or anything that takes a while to boot.

### Example:

```yaml
startupProbe:
  httpGet:
    path: /startup
    port: 8080
  failureThreshold: 30
  periodSeconds: 10
```

### Key Properties:
| Property             | Description                                                       |
|----------------------|-------------------------------------------------------------------|
| `failureThreshold`   | Often set high (e.g., 30) to allow long startup time              |
| `periodSeconds`      | How often to check during startup                                 |
| Other properties     | Same as liveness/readiness (e.g., `httpGet`, `initialDelaySeconds`) |

---

## 🧠 Summary

| Probe Type     | Purpose                        | Failing Result                  | When It Runs                   |
|----------------|--------------------------------|----------------------------------|--------------------------------|
| Liveness Probe | Is the app still alive?        | Container is restarted           | Periodically after startup     |
| Readiness Probe| Is the app ready for traffic?  | Removed from Service endpoints   | Periodically after startup     |
| Startup Probe  | Is the app still starting up?  | Container is restarted           | Runs first, disables others    |

> ✅ **Best Practice**: Use all three probes where needed:
> - Use `startupProbe` for slow apps
> - Use `readinessProbe` to protect traffic
> - Use `livenessProbe` to ensure health

