# ⚙️ Kubernetes Resource Requests, Limits, and Quality of Service (QoS) Classes

Kubernetes allows you to control how much **CPU and memory** your containers get through **resource requests and limits**. These settings also influence how the **Kubernetes scheduler** places Pods and how the system treats them under resource pressure.

---

## 🧮 Resource Requests and Limits

### 🔹 Requests

- **Minimum** amount of CPU or memory guaranteed to the container.
- Used by the scheduler to place the pod on a node with sufficient resources.

### 🔸 Limits

- **Maximum** amount of CPU or memory the container can use.
- If the container tries to exceed its limit:
  - **Memory**: Container is killed (OOMKilled).
  - **CPU**: Container is throttled, not killed.

---

## 🧪 Example: Setting CPU and Memory Resources

```yaml
resources:
  requests:
    memory: "128Mi"
    cpu: "250m"
  limits:
    memory: "256Mi"
    cpu: "500m"
```

- `cpu: 250m` means 0.25 CPU cores
- `memory: 128Mi` means 128 mebibytes

---

## 🏷️ Quality of Service (QoS) Classes

Kubernetes assigns a **QoS class** to each Pod based on how you set resource requests and limits. This affects how the Pod behaves during **resource contention**.

### 1. **Guaranteed**

**Requirements:**
- Every container in the Pod has **equal `requests` and `limits` set for both CPU and memory**

**Behavior:**
- Highest scheduling priority
- Last to be evicted when the node is under pressure

**Example:**

```yaml
resources:
  requests:
    memory: "256Mi"
    cpu: "500m"
  limits:
    memory: "256Mi"
    cpu: "500m"
```

---

### 2. **Burstable**

**Requirements:**
- Requests and limits are set, but **not equal**
- Or only some containers specify them

**Behavior:**
- Middle priority
- Evicted after Guaranteed pods under pressure

**Example:**

```yaml
resources:
  requests:
    memory: "128Mi"
    cpu: "250m"
  limits:
    memory: "256Mi"
    cpu: "500m"
```

---

### 3. **BestEffort**

**Requirements:**
- No resource requests or limits specified at all

**Behavior:**
- Lowest priority
- First to be evicted when the node runs out of resources

**Example:**

```yaml
# No resources section at all
```

---

## 🧠 Summary Table

| QoS Class   | CPU & Memory Requests | CPU & Memory Limits | Priority  | Notes                              |
|-------------|------------------------|----------------------|-----------|-------------------------------------|
| Guaranteed  | ✅ Yes (equal to limits)| ✅ Yes (equal to requests) | 🔼 Highest | Best resilience under pressure      |
| Burstable   | ✅ Yes                 | ✅ Optional           | 🔼 Medium  | Allows some bursting                |
| BestEffort  | 🚫 None                | 🚫 None               | 🔽 Lowest  | Evicted first, no guarantees        |

---

> ✅ **Best Practice**: Always set at least `requests` to help the scheduler and avoid unexpected evictions. Use limits when you want to cap usage.

